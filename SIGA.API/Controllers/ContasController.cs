using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureIdentity.Password;
using SIGA.API.Services;
using SIGA.Lib.DTOs;
using SIGA.Lib.DTOs.Funcionario;
using SIGA.Lib.Extensions;
using SIGA.Lib.Models;
using SIGA.Repositories.Exceptions;
using SIGA.Repositories.Interfaces;

namespace SIGA.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class ContasController : ControllerBase
{
	private readonly IContaRepository _contaRepository;
	private readonly IMapper _mapper;

	public ContasController(IContaRepository contaRepository, IMapper mapper)
	{
		_contaRepository = contaRepository;
		_mapper = mapper;
	}

	[HttpPost]
	public async Task<IActionResult> PostContaAsync(RegistroContaDTO model)
	{
		if (!ModelState.IsValid)
			return BadRequest(new ResponseDTO<string>(ModelState.GetErrors()));

		try
		{
			var funcionario = _mapper.Map<Funcionario>(model);

			await _contaRepository.Save(funcionario);

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
	public async Task<IActionResult> LoginAsync(LoginDTO model,TokenService tokenService)
	{
		if (!ModelState.IsValid)
			return BadRequest(new ResponseDTO<string>(ModelState.GetErrors()));

		try
		{
			var funcionario = await _contaRepository.GetByLogin(model.Login);

			if (funcionario is null)
				return BadRequest(new ResponseDTO<string>("E02 - Usuário ou Senha inválidos"));

			if (!PasswordHasher.Verify(funcionario.PasswordHash, model.Password))
				return BadRequest(new ResponseDTO<string>("E02 - Usuário ou Senha inválidos"));

			var token = tokenService.GenerateToken(funcionario);

			var funcionarioDto = _mapper.Map<LoginResponseDTO>(funcionario);
			funcionarioDto.Token = token;

			return Ok(new ResponseDTO<LoginResponseDTO>(funcionarioDto));
		}
		catch
		{
			return Problem("E01 - Falha interna no servidor");
		}
	}

	[HttpPut("{id}")]
	[Authorize]
	public async Task<IActionResult> PutContaAsync(int id, UpdateFuncionarioDTO model)
	{
		if (id != model.Id)
		{
			return BadRequest();
		}

		if (!ModelState.IsValid)
			return BadRequest(new ResponseDTO<string>(ModelState.GetErrors()));

		try
		{
			var funcionario = _mapper.Map<Funcionario>(model);

			await _contaRepository.Update(funcionario);

			return Ok(ResponseDTO<string>.ReturnSucess("Atualização realizada com sucesso!"));
		}
		catch (DbUpdateException ex)
		{
			return NotFound(new ResponseDTO<string>(ex.Message));
		}
		catch (DataNotFoundException ex)
		{
			return NotFound(new ResponseDTO<string>(ex.Message));
		}
		catch (Exception)
		{
			return Problem("E01 - Falha interna no servidor");
		}
	}

	[HttpDelete("{id}")]
	[Authorize]
	public async Task<IActionResult> DeleteContaAsync(int id)
	{
		try
		{
			await _contaRepository.Delete(id);

			return Ok(ResponseDTO<string>.ReturnSucess("Deleção realizada com sucesso!"));
		}
		catch (DbUpdateException ex)
		{
			return NotFound(new ResponseDTO<string>(ex.Message));
		}
		catch (DataNotFoundException ex)
		{
			return NotFound(new ResponseDTO<string>(ex.Message));
		}
		catch (Exception)
		{
			return Problem("E01 - Falha interna no servidor");
		}
	}
}
