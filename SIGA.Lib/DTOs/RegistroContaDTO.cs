using SIGA.Lib.Models;
using System.ComponentModel.DataAnnotations;

namespace SIGA.Lib.DTOs;
public class RegistroContaDTO
{
    [Required(ErrorMessage = "Nome é obrigatório")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "E-mail é obrigatório")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Senha é obrigatória")]
    public string Password { get; set; }
}
