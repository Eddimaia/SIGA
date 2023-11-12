using AutoMapper;
using SIGA.Lib.DTOs.Concessao;
using SIGA.Lib.Models;

namespace SIGA.Lib.Mappings;
public class ConcessaoMappingProfile : Profile
{
    public ConcessaoMappingProfile()
    {
        CreateMap<Concessao, ConcessaoDTO>()
            .ReverseMap();
    }
}
