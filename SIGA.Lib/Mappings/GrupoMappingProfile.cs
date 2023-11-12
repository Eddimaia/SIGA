using AutoMapper;
using SIGA.Lib.DTOs.Grupo;
using SIGA.Lib.Models;

namespace SIGA.Lib.Mappings;
public class GrupoMappingProfile : Profile
{
    public GrupoMappingProfile()
    {
        CreateMap<Grupo, GrupoDTO>()
            .ReverseMap();
    }
}
