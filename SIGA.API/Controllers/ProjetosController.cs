using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIGA.Domain.DTOs;
using SIGA.Domain.DTOs.Projeto;
using SIGA.Domain.Entities;
using SIGA.Domain.Extensions;
using SIGA.Repositories.Exceptions;
using SIGA.Repositories.Interfaces;

namespace SIGA.API.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class ProjetosController : ControllerBase
	{
		private readonly IProjetoRepository _projetoRepository;
		private readonly IMapper _mapper;

		public ProjetosController(IProjetoRepository projetoRepository, IMapper mapper)
		{
			_projetoRepository = projetoRepository;
			_mapper = mapper;
		}

		// GET: api/Projetos
		[HttpGet]
		[Authorize]
		public async Task<ActionResult<IEnumerable<ProjetoDTO>>> GetProjetosAsync()
		{
			try
			{
				var projetos = await _projetoRepository.GetAll();
				var response = _mapper.Map<IEnumerable<ProjetoDTO>>(projetos);
				return Ok(new ResponseDTO<IEnumerable<ProjetoDTO>>(response));
			}
			catch (Exception ex)
			{
				return Problem(ex.Message);
			}
		}

		// GET: api/Projetos/5
		[HttpGet("{id}")]
		[Authorize]
		public async Task<ActionResult<ProjetoDTO>> GetProjetoAsync(int id)
		{
			try
			{
				var projeto = await _projetoRepository.GetById(id);
				var response = _mapper.Map<ProjetoDTO>(projeto);

				return Ok(new ResponseDTO<ProjetoDTO>(response));
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

		// PUT: api/Projetos/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> PutProjetoAsync(int id, ProjetoDTO model)
		{
			if (id != model.Id)
			{
				return BadRequest();
			}

			if (!ModelState.IsValid)
				return BadRequest(new ResponseDTO<string>(ModelState.GetErrors()));

			try
			{
				var projeto = _mapper.Map<Projeto>(model);
				await _projetoRepository.Update(projeto);

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

		// POST: api/Projetos
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> PostProjetoAsync(ProjetoDTO model)
		{
			if (!ModelState.IsValid)
				return BadRequest(new ResponseDTO<string>(ModelState.GetErrors()));

			try
			{
				var projeto = _mapper.Map<Projeto>(model);
				await _projetoRepository.Save(projeto);

				return Ok(ResponseDTO<string>.ReturnSucess("Projeto criado com sucesso!"));
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

		// DELETE: api/Projetos/5
		[HttpDelete("{id}")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> DeleteProjeto(int id)
		{
			try
			{
				await _projetoRepository.Delete(id);

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
}
