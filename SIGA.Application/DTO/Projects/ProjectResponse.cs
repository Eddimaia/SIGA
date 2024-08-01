using SIGA.Domain.Entities;

namespace SIGA.Application.DTO.Projects;
public class ProjectResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Acronym { get; set; } = "N/A";
    public string ImagePath { get; set; } = null!;

    public static ProjectResponse ProjectToProjectResponse(Project project)
    {
        return new()
        {
            Id = project.Id,
            Name = project.Name,
            Acronym = project.Acronym,
            ImagePath = project.ImagePath,
        };
    }
}
