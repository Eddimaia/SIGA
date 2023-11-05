using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureIdentity.Password;
using SIGA.API.Repositories.Interfaces;
using SIGA.API.Services;
using SIGA.Lib.DTOs;
using SIGA.Lib.Extensions;
using SIGA.Lib.Models;

namespace SIGA.API.Controllers;

public class ContaController : ControllerBase
{
	private readonly IContaRepository _contaRepository;

	public ContaController(IContaRepository contaRepository)
	{
		_contaRepository = contaRepository;
	}
	[HttpPost("v1/contas")]
	public async Task<IActionResult> Post(
		[FromBody] RegistroContaDTO model, 
		[FromServices] IMapper mapper)
	{
		if (!ModelState.IsValid)
			return BadRequest(new ResponseDTO<string>(ModelState.GetErrors()));

		try
		{
			var funcionario = mapper.Map<Funcionario>(model);

			await _contaRepository.Register(funcionario);

			return Ok("Cadastro realizado com sucesso!");
		}
		catch (DbUpdateException)
		{
			return StatusCode(400, new ResponseDTO<string>("E02 - Este E-mail já está cadastrado"));
		}
		catch (Exception)
		{
			return StatusCode(500, new ResponseDTO<string>("E01 - Falha interna no servidor"));
		}
	}

	[HttpPost("v1/contas/login")]
	public async Task<IActionResult> Login([FromBody] LoginDTO model, [FromServices] TokenService tokenService)
	{
		if (!ModelState.IsValid)
			return BadRequest(new ResponseDTO<string>(ModelState.GetErrors()));

		try
		{
			var funcionario = await _contaRepository.GetByLogin(model.Login);

			if (funcionario is null)
				return StatusCode(401, new ResponseDTO<string>("E02 - Usuário ou Senha inválidos"));

			if (!PasswordHasher.Verify(funcionario.PasswordHash, model.Password))
				return StatusCode(401, new ResponseDTO<string>("E02 - Usuário ou Senha inválidos"));

			var token = tokenService.GenerateToken(funcionario);

			return Ok(new ResponseDTO<string>(token, null));
		}
		catch
		{
			return StatusCode(500, new ResponseDTO<string>("E01 - Falha interna no servidor"));
		}
	}
}
