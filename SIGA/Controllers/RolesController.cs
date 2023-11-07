using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIGA.API.Exceptions;
using SIGA.API.Repositories.Interfaces;
using SIGA.Lib.DTOs;
using SIGA.Lib.Extensions;
using SIGA.Lib.Models;

namespace SIGA.API.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class RolesController : ControllerBase
	{
		private readonly IRoleRepository _roleRepository;

		public RolesController(IRoleRepository roleRepository)
		{
			_roleRepository = roleRepository;
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
				return NotFound(ex);
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
		[Authorize(Roles = "Master")]
		public async Task<IActionResult> PutRoleAsync(int id, Role model)
		{
			if (id != model.Id)
			{
				return BadRequest();
			}

			if (!ModelState.IsValid)
				return BadRequest(new ResponseDTO<string>(ModelState.GetErrors()));

			try
			{
				await _roleRepository.Update(model);

				return Ok(new ResponseDTO<string>("Atualização realizada com sucesso!"));
			}
			catch (DbUpdateException ex)
			{
				return NotFound(ex);
			}
			catch (DataNotFoundException ex)
			{
				return NotFound(ex);
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
		[Authorize(Roles = "Master")]
		public async Task<IActionResult> PostRoleAsync(Role model)
		{
			if (!ModelState.IsValid)
				return BadRequest(new ResponseDTO<string>(ModelState.GetErrors()));

			try
			{
				await _roleRepository.Save(model);

				return Ok(new ResponseDTO<string>("Atualização realizada com sucesso!"));
			}
			catch (DbUpdateException ex)
			{
				return NotFound(ex);
			}
			catch (DataNotFoundException ex)
			{
				return NotFound(ex);
			}
			catch (Exception)
			{
				return Problem("E01 - Falha interna no servidor");
			}
		}

		// DELETE: api/Roles/5
		[HttpDelete("{id}")]
		[Authorize(Roles = "Admin")]
		[Authorize(Roles = "Master")]
		public async Task<IActionResult> DeleteRole(int id)
		{
			try
			{
				await _roleRepository.Delete(id);

				return Ok(new ResponseDTO<string>("Deleção realizada com sucesso!"));
			}
			catch (DbUpdateException ex)
			{
				return NotFound(ex);
			}
			catch (DataNotFoundException ex)
			{
				return NotFound(ex.Message);
			}
			catch (Exception)
			{
				return Problem("E01 - Falha interna no servidor");
			}
		}
	}
}
