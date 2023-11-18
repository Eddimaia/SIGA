using AutoMapper;
using SIGA.Domain.DTOs.Concessao;
using SIGA.Domain.Entities;

namespace SIGA.Domain.Mappings;
public class ConcessaoMappingProfile : Profile
{
    public ConcessaoMappingProfile()
    {
        CreateMap<Concessao, ConcessaoDTO>()
            .ReverseMap();
    }
}
