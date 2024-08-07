using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SIGA.Application.DTO.Common;
using SIGA.Application.DTO.Employee;
using SIGA.Application.Handles.Interfaces;
using SIGA.Infrastructure.Context;

namespace SIGA.IoC.Handles;
public class EmployeeHandler(AppDbContext context) : IEmployeeHandler
{
    public async Task<Response<IEnumerable<EmployeeResponse>>> GetAllAsync()
    {
        try
        {
            var result = await context.Users
                .AsNoTracking()
                .OrderBy(x => x.FirstName)
                .ToListAsync();

            return new Response<IEnumerable<EmployeeResponse>>(
                result
                .Select(EmployeeResponse.AplicationUserToEmployeeResponse), 
                StatusCodes.Status200OK, 
                null);
        }
        catch
        {
            return new Response<IEnumerable<EmployeeResponse>>(null, 500, "Não foi possível consultar os funcionários");
        }
    }

    public async Task<PagedResponse<IEnumerable<EmployeeResponse>>> GetAsync(PagedEmployeeRequest request)
    {
        try
        {
            var query = context.Users
            .Where(x => x.IsEmployed
            && (string.IsNullOrEmpty(request.SearchString) ? true : x.FirstName.Contains(request.SearchString) || x.LastName.Contains(request.SearchString))
            )
            .AsNoTracking()
            .OrderBy(x => x.Id);

            var result = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

            var count = await query.CountAsync();

            return new PagedResponse<IEnumerable<EmployeeResponse>>(
                   result
                   .Select(EmployeeResponse.AplicationUserToEmployeeResponse),
                   count,
                   request.PageNumber,
                   request.PageSize);
        }
        catch
        {
            return new PagedResponse<IEnumerable<EmployeeResponse>>(null, 500, "Não foi possível consultar os funcionários");
        }
    }
}
