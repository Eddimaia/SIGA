using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIGA.API.Services;
using SIGA.Domain.DTOs;
using SIGA.Domain.Entities;
using SIGA.Domain.Extensions;

namespace SIGA.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class ContasController : ControllerBase
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public ContasController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    [HttpPost("Registrar")]
    [AllowAnonymous]
    public async Task<IActionResult> PostContaAsync([FromBody] Usuario model)
    {
        ArgumentNullException.ThrowIfNull(model);

        if ( !ModelState.IsValid )
            return BadRequest(new ResponseDTO<string>(ModelState.GetErrors()));


        try
        {
            var appUser = new ApplicationUser { UserName = model.Login, Email = model.Email };

            var result = await _userManager.CreateAsync(appUser, model.Senha);

            var user = await _userManager.FindByEmailAsync(model.Email);
            if ( user != null )
            {
                await _userManager.AddToRoleAsync(user, "Admin");
            }

            return Ok(ResponseDTO<string>.ReturnSucess("Cadastro realizado com sucesso!"));
        }
        catch ( DbUpdateException )
        {
            return Conflict(new ResponseDTO<string>("E02 - Este E-mail já está cadastrado"));
        }
        catch ( Exception )
        {
            return Problem("E01 - Falha interna no servidor");
        }
    }

    [HttpPost("Login")]
    [AllowAnonymous]
    public async Task<ActionResult<UsuarioToken>> LoginAsync(
        [FromBody] Usuario model,
        [FromServices] TokenService tokenService)
    {
        ArgumentNullException.ThrowIfNull(model);

        ArgumentNullException.ThrowIfNull(tokenService);

        if ( !ModelState.IsValid )
            return BadRequest(new ResponseDTO<string>(ModelState.GetErrors()));

        try
        {
            var result = await _signInManager.PasswordSignInAsync(model.Login, model.Senha, isPersistent: false, lockoutOnFailure: false);

            if ( result.Succeeded )
                return Ok(new ResponseDTO<UsuarioToken>(tokenService.GenerateToken(User)));
            else
                return BadRequest();
        }
        catch
        {
            return Problem("E01 - Falha interna no servidor");
        }
    }

    [HttpPost("AddRole")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> ContaAddToRoleAsync([FromQuery] string usuarioId, [FromQuery] string roleId)
    {
        ArgumentNullException.ThrowIfNull(usuarioId);
        ArgumentNullException.ThrowIfNull(roleId);

        try
        {
            var user = await _userManager.FindByIdAsync(usuarioId);

            if ( user is null )
                return NotFound(ResponseDTO<string>.ReturnSucess("Usuário não encontrado!"));

            var role = await _roleManager.FindByIdAsync(roleId);

            if ( role is not null )
                await _userManager.AddToRoleAsync(user, role.Name);

            return Ok(ResponseDTO<string>.ReturnSucess("Cadastro realizado com sucesso!"));
        }
        catch ( DbUpdateException )
        {
            return Conflict(new ResponseDTO<string>("E02 - Este E-mail já está cadastrado"));
        }
        catch ( Exception )
        {
            return Problem("E01 - Falha interna no servidor");
        }
    }
}
