using AutoMapper;
using SIGA.Domain.DTOs.Projeto;
using SIGA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGA.Domain.Mappings;
public class ProjetoMappingProfile : Profile
{
    public ProjetoMappingProfile()
    {
        CreateMap<Projeto, ProjetoDTO>()
            .ReverseMap();
    }
}
