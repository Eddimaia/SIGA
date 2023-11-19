using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIGA.Domain.DTOs;
using SIGA.Domain.DTOs.Funcionario;
using SIGA.Domain.Entities;
using SIGA.Domain.Extensions;
using SIGA.Repositories.Exceptions;
using SIGA.Repositories.Interfaces;

namespace SIGA.API.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class RolesController : ControllerBase
	{
		private readonly IRoleRepository _roleRepository;
		private readonly IMapper _mapper;

		public RolesController(IRoleRepository roleRepository, IMapper mapper)
		{
			_roleRepository = roleRepository;
			_mapper = mapper;
		}

		// GET: api/Roles
		[HttpGet]
		[Authorize]
		public async Task<ActionResult<IEnumerable<Role>>> GetRolesAsync()
		{
			try
			{
				var roles = await _roleRepository.GetAll();
				return Ok(new ResponseDTO<IEnumerable<Role>>(roles));
			}
			catch (Exception ex)
			{
				return Problem(ex.Message);
			}
		}

		// GET: api/Roles/5
		[HttpGet("{id}")]
		[Authorize]
		public async Task<ActionResult<Role>> GetRoleAsync(int id)
		{
			try
			{
				var role = await _roleRepository.GetById(id);

				return Ok(new ResponseDTO<Role>(role));
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

		// PUT: api/Roles/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> PutRoleAsync(int id, Role model)
		{
			//if (id.ToString() != model.Id)
			//{
			//	return BadRequest();
			//}

			if (!ModelState.IsValid)
				return BadRequest(new ResponseDTO<string>(ModelState.GetErrors()));

			try
			{
				await _roleRepository.Update(model);

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

		// POST: api/Roles
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> PostRoleAsync(Role model)
		{
			if (!ModelState.IsValid)
				return BadRequest(new ResponseDTO<string>(ModelState.GetErrors()));

			try
			{
				await _roleRepository.Save(model);

				return Ok(ResponseDTO<string>.ReturnSucess("Role criada com sucesso!"));
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

		// DELETE: api/Roles/5
		[HttpDelete("{id}")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> DeleteRole(int id)
		{
			try
			{
				await _roleRepository.Delete(id);

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

		[HttpGet("funcionarios/{id}")]
		[Authorize]
		public async Task<ActionResult<IEnumerable<FuncionarioDTO>>> GetFuncionariosByRoleAsync(int id)
		{
			try
			{
				var funcionarios = await _roleRepository.GetFuncionariosByRole(id);

				var retorno = _mapper.Map<IEnumerable<FuncionarioDTO>>(funcionarios);

				return Ok(new ResponseDTO<IEnumerable<FuncionarioDTO>>(retorno));
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
}
