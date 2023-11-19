using AutoMapper;
using SIGA.Domain.DTOs;
using SIGA.Domain.Entities;

namespace SIGA.Domain.Mappings;
public class RoleMappingProfile : Profile
{
    public RoleMappingProfile()
    {
        CreateMap<Role, RoleDTO>().ReverseMap();
    }
}
