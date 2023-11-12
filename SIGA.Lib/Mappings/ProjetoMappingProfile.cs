using AutoMapper;
using SIGA.Lib.DTOs.Projeto;
using SIGA.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGA.Lib.Mappings;
public class ProjetoMappingProfile : Profile
{
    public ProjetoMappingProfile()
    {
        CreateMap<Projeto, ProjetoDTO>()
            .ReverseMap();
    }
}
