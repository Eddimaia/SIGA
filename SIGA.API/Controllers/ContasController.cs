using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureIdentity.Password;
using SIGA.API.Services;
using SIGA.Domain.DTOs;
using SIGA.Domain.Entities;
using SIGA.Domain.Extensions;
using SIGA.Repositories.Interfaces;

namespace SIGA.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class ContasController : ControllerBase
{
	private readonly SignInManager<ApplicationUser> _signInManager;
	private readonly UserManager<ApplicationUser> _userManager;

	public ContasController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
	{
		_signInManager = signInManager;
		_userManager = userManager;
	}

	[HttpPost("registrar")]
	[AllowAnonymous]
	public async Task<IActionResult> PostContaAsync([FromBody] Usuario model)
	{
		if (!ModelState.IsValid)
			return BadRequest(new ResponseDTO<string>(ModelState.GetErrors()));



		try
		{
			var appUser = new ApplicationUser { UserName = model.Email, Email = model.Email };

			var result = await _userManager.CreateAsync(appUser, model.Senha);

			return Ok(ResponseDTO<string>.ReturnSucess("Cadastro realizado com sucesso!"));
		}
		catch (DbUpdateException)
		{
			return Conflict(new ResponseDTO<string>("E02 - Este E-mail já está cadastrado"));
		}
		catch (Exception)
		{
			return Problem("E01 - Falha interna no servidor");
		}
	}

	[HttpPost("login")]
	[AllowAnonymous]
	public async Task<ActionResult<UsuarioToken>> LoginAsync([FromBody] Usuario model, TokenService tokenService)
	{
		if (!ModelState.IsValid)
			return BadRequest(new ResponseDTO<string>(ModelState.GetErrors()));

		try
		{
			//var funcionario = await _contaRepository.GetByLogin(model.Login);

			//if (funcionario is null)
			//	return BadRequest(new ResponseDTO<string>("E02 - Usuário ou Senha inválidos"));

			//if (!PasswordHasher.Verify(funcionario.PasswordHash, model.Password))
			//	return BadRequest(new ResponseDTO<string>("E02 - Usuário ou Senha inválidos"));

			//var token = tokenService.GenerateToken(funcionario);

			//var funcionarioDto = _mapper.Map<LoginResponseDTO>(funcionario);
			//funcionarioDto.Token = token;

			var result = await _signInManager.PasswordSignInAsync(model.Email, model.Senha, isPersistent: false, lockoutOnFailure: false);

			if (result.Succeeded)
				return Ok(new ResponseDTO<UsuarioToken>(tokenService.GenerateToken(model)));
			else
				return BadRequest();
		}
		catch
		{
			return Problem("E01 - Falha interna no servidor");
		}
	}
}
