using System.ComponentModel.DataAnnotations;

namespace SIGA.Application.DTO.Projects;
public class CreateProjectRequest
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [MaxLength(50, ErrorMessage = "O campo {0} pode ter no máximo 50 caracteres")]
    public string Name { get; set; } = null!;


    [MaxLength(10, ErrorMessage = "O campo {0} pode ter no máximo 10 caracteres")]
    public string? Acronym { get; set; }


    [Base64String(ErrorMessage = "O campo {0} deve ser do tipo Base64")]
    public string? ImageBase64 { get; set; }
    public int? CoordinatorId { get; set; }
    public IEnumerable<int> UsersIds { get; set; } = [];
}
