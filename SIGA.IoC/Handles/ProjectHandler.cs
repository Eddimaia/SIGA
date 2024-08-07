using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using SIGA.Application.DTO.Common;
using SIGA.Application.DTO.Projects;
using SIGA.Application.Handles.Interfaces;
using SIGA.Domain.Entities;
using SIGA.Infrastructure.Context;
using System.Drawing.Imaging;


namespace SIGA.IoC.Handles;
public class ProjectHandler(AppDbContext context, IWebHostEnvironment webHostEnvironment) : IProjectHandler
{
    public async Task<Response<ProjectResponse?>> CreateAsync(CreateProjectRequest request)
    {
        var project = new Project
        {
            Name = request.Name,
            Acronym = request.Acronym ?? GenerateAcronym(request.Name)
        };

        try
        {

            if (request.CoordinatorId is not null)
                project.Coordinator = await context.Users.FindAsync(request.CoordinatorId);

            foreach (var userId in request.UsersIds)
            {
                var user = await context.Users.FindAsync(userId);
                if (user is not null)
                    project.ApplicationUsers.Add(user);
            }

            if (!string.IsNullOrEmpty(request.ImageBase64))
            {
                var fileName = request.Acronym + "_logo.jpeg";
                byte[] imageBytes = Convert.FromBase64String(request.ImageBase64);
                using var ms = new MemoryStream(imageBytes);
                using var image = System.Drawing.Image.FromStream(ms);

                string wwwRootPath = webHostEnvironment.WebRootPath;
                string imagePath = Path.Combine(wwwRootPath, "projectImg", fileName);

                Directory.CreateDirectory(Path.GetDirectoryName(imagePath)!);

                image.Save(imagePath, ImageFormat.Jpeg);

                project.ImagePath = imagePath;
            }

            context.Projects.Add(project);

            await context.SaveChangesAsync();

            var projectResponse = new ProjectResponse
            {
                Id = project.Id,
                Name = project.Name,
                Acronym = project.Acronym,
                ImagePath = project.ImagePath
            };

            return new Response<ProjectResponse?>(projectResponse, 201, "Projeto criado com sucesso");
        }
        catch (Exception ex)
        {
            if (!string.IsNullOrEmpty(project.ImagePath))
                File.Delete(project.ImagePath);

            return new Response<ProjectResponse?>(null, 500, $"Não foi possível criar o projeto: {ex.Message}");
        }
    }

    public async Task<Response<ProjectResponse?>> DeleteAsync(int id)
    {
        try
        {
            var project = await context
            .Projects
            .FindAsync(id);

            if (project is null)
                return new Response<ProjectResponse?>(null, 404, "Projeto não encontrado");

            context.Projects.Remove(project);
            await context.SaveChangesAsync();

            return new Response<ProjectResponse?>(ProjectResponse.ProjectToProjectResponse(project), message: "Categoria excluída com sucesso!");
        }
        catch
        {
            return new Response<ProjectResponse?>(null, 500, "Não foi possível excluir o projeto");
        }
    }

    public async Task<PagedResponse<List<ProjectResponse>>> GetAsync(PagedProjectRequest request)
    {
        try
        {
            var query = context.Projects
            .AsNoTracking()
            .Where(item => string.IsNullOrWhiteSpace(request.SearchString)
            || item.Name.Contains(request.SearchString)
            || item.Acronym.Contains(request.SearchString)
            ).OrderBy(x => x.Id);

            var result = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

            var count = await query.CountAsync();

            return new PagedResponse<List<ProjectResponse>>(
                   result
                   .Select(ProjectResponse.ProjectToProjectResponse)
                   .ToList(),
                   count,
                   request.PageNumber,
                   request.PageSize);
        }
        catch
        {
            return new PagedResponse<List<ProjectResponse>>(null, 500, "Não foi possível consultar os projetos");
        }
    }

    private string GenerateAcronym(string projectName)
    {
        var parts = projectName.Split(' ');
        var acronym = string.Empty;

        foreach (var part in parts)
            acronym += part[0].ToString().ToUpperInvariant();

        return acronym;
    }
}
