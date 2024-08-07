using SIGA.Domain.Entities;

namespace SIGA.Application.DTO.Employee;
public class EmployeeResponse
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string? ImagePath { get; set; }
    public bool IsCoordinator { get; set; }

    public static EmployeeResponse AplicationUserToEmployeeResponse(ApplicationUser applicationUser)
    {
        return new()
        {
            Id = applicationUser.Id,
            FullName = applicationUser.FirstName + " " + applicationUser.LastName,
            ImagePath = applicationUser.ImagePath,
            IsCoordinator = applicationUser.IsProjectCoordinator
        };
    }
}
