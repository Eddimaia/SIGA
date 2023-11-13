using AutoMapper;
using SIGA.Lib.DTOs;
using SIGA.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGA.Lib.Mappings;
public class RoleMappingProfile : Profile
{
    public RoleMappingProfile()
    {
        CreateMap<Role, RoleDTO>().ReverseMap();
    }
}
