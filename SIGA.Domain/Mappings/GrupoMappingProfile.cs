using AutoMapper;
using SIGA.Domain.DTOs.Grupo;
using SIGA.Domain.Entities;

namespace SIGA.Domain.Mappings;
public class GrupoMappingProfile : Profile
{
    public GrupoMappingProfile()
    {
        CreateMap<Grupo, GrupoDTO>()
            .ReverseMap();
    }
}
