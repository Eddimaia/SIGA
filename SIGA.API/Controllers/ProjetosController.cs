using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIGA.Lib.DTOs;
using SIGA.Lib.Extensions;
using SIGA.Lib.Models;
using SIGA.Repositories.Exceptions;
using SIGA.Repositories.Interfaces;

namespace SIGA.API.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class ProjetosController : ControllerBase
	{
		private readonly IProjetoRepository _projetoRepository;

		public ProjetosController(IProjetoRepository projetoRepository)
		{
			_projetoRepository = projetoRepository;
		}

		// GET: api/Projetos
		[HttpGet]
		[Authorize]
		public async Task<ActionResult<IEnumerable<Projeto>>> GetProjetosAsync()
		{
			try
			{
				var projetos = await _projetoRepository.GetAll();
				return Ok(new ResponseDTO<IEnumerable<Projeto>>(projetos));
			}
			catch (Exception ex)
			{
				return Problem(ex.Message);
			}
		}

		// GET: api/Projetos/5
		[HttpGet("{id}")]
		[Authorize]
		public async Task<ActionResult<Projeto>> GetProjetoAsync(int id)
		{
			try
			{
				var projeto = await _projetoRepository.GetById(id);

				return Ok(new ResponseDTO<Projeto>(projeto));
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
		public async Task<IActionResult> PutProjetoAsync(int id, Projeto model)
		{
			if (id != model.Id)
			{
				return BadRequest();
			}

			if (!ModelState.IsValid)
				return BadRequest(new ResponseDTO<string>(ModelState.GetErrors()));

			try
			{
				await _projetoRepository.Update(model);

				return Ok(new ResponseDTO<string>("Atualização realizada com sucesso!"));
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
		public async Task<IActionResult> PostProjetoAsync(Projeto model)
		{
			if (!ModelState.IsValid)
				return BadRequest(new ResponseDTO<string>(ModelState.GetErrors()));

			try
			{
				await _projetoRepository.Save(model);

				return Ok(new ResponseDTO<string>("Atualização realizada com sucesso!"));
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

				return Ok(new ResponseDTO<string>("Deleção realizada com sucesso!"));
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
