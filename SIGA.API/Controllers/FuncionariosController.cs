using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIGA.Domain.DTOs.Funcionario;
using SIGA.Domain.DTOs;
using SIGA.Repositories.Exceptions;
using AutoMapper;
using SIGA.Repositories.Interfaces;
using SIGA.Domain.Extensions;
using SIGA.Domain.Entities;

namespace SIGA.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class FuncionariosController : ControllerBase
{
    private readonly IFuncionarioRepository _funcionarioRepository;
    private readonly IMapper _mapper;

    public FuncionariosController(IFuncionarioRepository contaRepository, IMapper mapper)
    {
        _funcionarioRepository = contaRepository;
        _mapper = mapper;
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> PutContaAsync(int id, UpdateFuncionarioDTO model)
    {
        if ( id != model.Id )
        {
            return BadRequest();
        }

        if ( !ModelState.IsValid )
            return BadRequest(new ResponseDTO<string>(ModelState.GetErrors()));

        try
        {
            var funcionario = _mapper.Map<Funcionario>(model);

            await _funcionarioRepository.Update(funcionario);

            return Ok(ResponseDTO<string>.ReturnSucess("Atualização realizada com sucesso!"));
        }
        catch ( DbUpdateException ex )
        {
            return NotFound(new ResponseDTO<string>(ex.Message));
        }
        catch ( DataNotFoundException ex )
        {
            return NotFound(new ResponseDTO<string>(ex.Message));
        }
        catch ( Exception )
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
            await _funcionarioRepository.Delete(id);

            return Ok(ResponseDTO<string>.ReturnSucess("Deleção realizada com sucesso!"));
        }
        catch ( DbUpdateException ex )
        {
            return NotFound(new ResponseDTO<string>(ex.Message));
        }
        catch ( DataNotFoundException ex )
        {
            return NotFound(new ResponseDTO<string>(ex.Message));
        }
        catch ( Exception )
        {
            return Problem("E01 - Falha interna no servidor");
        }
    }

    [HttpPut("Roles/{funcionarioId}")]
    [Authorize]
    public async Task<IActionResult> AddRoleAsync(int funcionarioId, IEnumerable<int> rolesIds)
    {
        if ( !ModelState.IsValid )
            return BadRequest(new ResponseDTO<string>(ModelState.GetErrors()));
        if ( rolesIds.Count().Equals(0) )
            return BadRequest();

        try
        {
            await _funcionarioRepository.AddRolesFuncionario(rolesIds, funcionarioId);

            return Ok(ResponseDTO<string>.ReturnSucess("Atualização realizada com sucesso!"));
        }
        catch ( DbUpdateException ex )
        {
            return NotFound(new ResponseDTO<string>(ex.Message));
        }
        catch ( DataNotFoundException ex )
        {
            return NotFound(new ResponseDTO<string>(ex.Message));
        }
        catch ( Exception )
        {
            return Problem("E01 - Falha interna no servidor");
        }
    }
}
