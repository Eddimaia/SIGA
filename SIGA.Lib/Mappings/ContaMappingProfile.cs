using AutoMapper;
using SIGA.Lib.DTOs;
using SIGA.Lib.Extensions;
using SIGA.Lib.Models;

namespace SIGA.Lib.Mappings;
public class ContaMappingProfile : Profile
{
	public ContaMappingProfile()
	{
		CreateMap<RegistroContaDTO, Funcionario>()
			.ForMember(destino => destino.PasswordHash, 
			map => map.MapFrom(
				src => src.Password.GetPasswordHash()));
	}
}
