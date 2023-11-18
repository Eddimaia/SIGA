using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIGA.Domain.DTOs;
using SIGA.Domain.Extensions;
using SIGA.Repositories.Exceptions;
using SIGA.Repositories.Interfaces;
using SIGA.Domain.DTOs.Grupo;
using SIGA.Domain.DTOs.Concessao;
using SIGA.Domain.Entities;

namespace SIGA.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class GruposController : ControllerBase
{
	private readonly IGrupoRepository _grupoRepository;
	private readonly IMapper _mapper;

	public GruposController(IGrupoRepository grupoRepository, IMapper mapper)
	{
		_grupoRepository = grupoRepository;
		_mapper = mapper;
	}

	// GET: api/v1/Grupos
	[HttpGet]
	[Authorize]
	public async Task<ActionResult<IEnumerable<GrupoDTO>>> GetGruposAsync()
	{
		try
		{
			var grupos = await _grupoRepository.GetAll();
			var response = _mapper.Map<IEnumerable<GrupoDTO>>(grupos);
			return Ok(new ResponseDTO<IEnumerable<GrupoDTO>>(response));
		}
		catch (Exception ex)
		{
			return Problem(ex.Message);
		}
	}

	// GET: api/v1/Grupos/5
	[HttpGet("{id}")]
	[Authorize]
	public async Task<ActionResult<GrupoDTO>> GetGrupoAsync(int id)
	{
		try
		{
			var grupo = await _grupoRepository.GetById(id);
			var response = _mapper.Map<GrupoDTO>(grupo);

			return Ok(new ResponseDTO<GrupoDTO>(response));
		}
		catch (DataNotFoundException ex)
		{
			return NotFound(new ResponseDTO<string>(ex.Message));
		}
		catch (Exception ex)
		{
			return Problem(ex.Message);
		}
	}

	// PUT: api/v1/Grupos/5
	// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
	[HttpPut("{id}")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> PutGrupoAsync(int id, GrupoDTO model)
	{
		if (id != model.Id)
			return BadRequest();

		if (!ModelState.IsValid)
			return BadRequest(new ResponseDTO<string>(ModelState.GetErrors()));

		var grupo = _mapper.Map<Grupo>(model);

		try
		{
			await _grupoRepository.Update(grupo);

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

	// POST: api/v1/Grupos
	// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
	[HttpPost]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> PostGrupoAsync(GrupoDTO model)
	{
		if (!ModelState.IsValid)
			return BadRequest(new ResponseDTO<string>(ModelState.GetErrors()));

		var grupo = _mapper.Map<Grupo>(model);

		try
		{
			await _grupoRepository.Save(grupo);

			return Ok(ResponseDTO<string>.ReturnSucess("Grupo criado com sucesso!"));
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

	// DELETE: api/v1/Grupos/5
	[HttpDelete("{id}")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> DeleteGrupo(int id)
	{
		try
		{
			await _grupoRepository.Delete(id);

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

	[HttpGet("concessoes/{id}")]
	[Authorize]
	public async Task<ActionResult<IEnumerable<ConcessaoDTO>>> GetFuncionariosByGrupoAsync(int id)
	{
		try
		{
			var concessoes = await _grupoRepository.GetConcessoesByGrupo(id);

			var retorno = _mapper.Map<IEnumerable<ConcessaoDTO>>(concessoes);

			return Ok(new ResponseDTO<IEnumerable<ConcessaoDTO>>(retorno));
		}
		catch (DataNotFoundException ex)
		{
			return NotFound(new ResponseDTO<string>(ex.Message));
		}
		catch (Exception ex)
		{
			return Problem(ex.Message);
		}
	}
}
