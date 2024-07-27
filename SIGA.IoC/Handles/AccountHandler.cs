using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SIGA.Application.DTO;
using SIGA.Application.DTO.Account;
using SIGA.Application.Handles.Interfaces;
using SIGA.Application.Services.Interfaces;
using SIGA.Domain.Entities;
using SIGA.Infrastructure.Context;

namespace SIGA.IoC.Handles;
public class AccountHandler(AppDbContext context, ILogger<AccountHandler> logger, IPasswordService passwordService, ITokenService tokenService) : IAccountHandler, ILogoutRefreshEndpointHandler
{
    public async Task<Response<LoginResponse?>> LoginAsync(LoginRequest request)
    {
        try
        {
            var user = await context.Users
                .AsNoTracking()
                .Include(u => u.Claims)
                .Include(u => u.Roles)
                .FirstOrDefaultAsync(userDb => userDb.Login == request.Login);

            if (user == null)
            {
                return new Response<LoginResponse?>(null, StatusCodes.Status404NotFound, "Usuário não encontrado");
            }

            var isPasswordValid = await passwordService.VerifyPassword(user.Password, request.Password);

            if (!isPasswordValid)
            {
                return new Response<LoginResponse?>(null, StatusCodes.Status401Unauthorized, "Login ou Senha inválidos");
            }

            var (token, refreshToken) = await tokenService.GenerateTokenAsync(user);

            return new Response<LoginResponse?>(new LoginResponse
            {
                Token = token,
                RefreshToken = refreshToken
            }, StatusCodes.Status200OK, "Login executado com sucesso");

        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            return new Response<LoginResponse?>(null, StatusCodes.Status500InternalServerError, "Não foi possível realizar o login do usuário");
        }
    }

    public Task<bool> LogoutAsync(string refreshToken)
    {
        try
        {
            return Task.FromResult(tokenService.ClearAutheticationStates(refreshToken));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            return Task.FromResult(false);
        }
    }

    public async Task<Response<LoginResponse?>> RefreshTokenAsync(RefreshTokenRequest request)
    {
        try
        {
            var user = await context.Users
                .AsNoTracking()
                .Include(u => u.Claims)
                .Include(u => u.Roles)
                .FirstOrDefaultAsync(userDb => userDb.Login == request.Login);

            if (user == null)
            {
                return new Response<LoginResponse?>(null, StatusCodes.Status404NotFound, "Usuário não encontrado");
            }

            var tokens = await tokenService.GenerateFromRefreshTokenAsync(user, request.RefreshToken);

            if (tokens.HasValue)
            {
                return new Response<LoginResponse?>(new LoginResponse
                {
                    Token = tokens.Value.token,
                    RefreshToken = tokens.Value.refreshToken
                }, 200, "Login executado com sucesso");
            }

            return new Response<LoginResponse?>(null, StatusCodes.Status422UnprocessableEntity, "Não foi possível realizar o refresh do token");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            return new Response<LoginResponse?>(null, StatusCodes.Status500InternalServerError, "Não foi possível realizar o refresh do token");
        }
    }

    public async Task<Response<RegisterResponse?>> RegisterAsync(RegisterRequest request)
    {
        await context.Database.BeginTransactionAsync();
        try
        {
            var passwordHash = await passwordService.HashPassword(request.Password);

            var user = new ApplicationUser
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Login = request.Login,
                UserName = request.UserName,
                Password = passwordHash,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                BirthDate = request.BirthDate.Value,
                CreatedAt = DateTimeOffset.Now,
                IsEmailConfirmed = false,
                IsPhoneNumberConfirmed = false,
                IsEmployed = request.IsEmployed,
                IsProjectCoordinator = request.IsProjectCoordinator
            };

            await context.AddAsync(user);

            await context.SaveChangesAsync();

            var response = new Response<RegisterResponse?>(new RegisterResponse
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            }, StatusCodes.Status201Created, "Usuário criado com sucesso");

            await context.Database.CommitTransactionAsync();
            return response;
        }
        catch (Exception ex)
        {
            await context.Database.RollbackTransactionAsync();
            logger.LogError(ex, ex.Message);
            return new Response<RegisterResponse?>(null, StatusCodes.Status500InternalServerError, "Não foi possível criar o usuário");
        }
    }
}
