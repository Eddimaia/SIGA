using AutoMapper;
using SIGA.Lib.DTOs;
using SIGA.Lib.DTOs.Funcionario;
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

		CreateMap<Funcionario, FuncionarioDTO>().ReverseMap();

		CreateMap<Funcionario, LoginResponseDTO>().ReverseMap();

		CreateMap<UpdateFuncionarioDTO, Funcionario>().ReverseMap();
	}
}
