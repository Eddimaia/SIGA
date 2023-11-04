using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIGA.API.Data;
using SIGA.Lib.DTOs;
using SIGA.Lib.Extensions;
using SIGA.Lib.Models;

namespace SIGA.API.Controllers;

public class ContaController : ControllerBase
{
    private readonly SIGAAppDbContext _context;

    public ContaController(SIGAAppDbContext context)
    {
        _context = context;
    }
    [HttpPost("v1/contas")]
    public async Task<IActionResult> Post([FromBody] RegistroContaDTO model)
    {
        if ( !ModelState.IsValid )
            return BadRequest(new ResponseDTO<string>(ModelState.GetErrors()));

        using var transaction = _context.Database.BeginTransaction();
        try
        {
            var funcionario = new Funcionario
            {
                Nome = model.Nome,
                Email = model.Email,
                PasswordHash = model.Password.GerarSenha()
            };

            await _context.Funcionarios.AddAsync(funcionario);
            await _context.SaveChangesAsync();

            transaction.Commit();
            return Ok(new ResponseDTO<dynamic>(new
            {
                funcionario
            }));
        }
        catch ( DbUpdateException )
        {
            transaction.Rollback();
            return StatusCode(400, new ResponseDTO<string>("C1xE02 - Este E-mail já está cadastrado"));
        }
        catch ( Exception ex )
        {
            transaction.Rollback();
            await _context.SaveChangesAsync(false);
            return StatusCode(500, new ResponseDTO<string>("C1xE01 - Falha interna no servidor"));
        }
    }
}
