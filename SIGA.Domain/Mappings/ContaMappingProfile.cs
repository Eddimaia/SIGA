using AutoMapper;
using SecureIdentity.Password;
using SIGA.Domain.DTOs;
using SIGA.Domain.DTOs.Funcionario;
using SIGA.Domain.Entities;

namespace SIGA.Domain.Mappings;
public class ContaMappingProfile : Profile
{
	public ContaMappingProfile()
	{
		CreateMap<RegistroContaDTO, Funcionario>()
			.ForMember(destino => destino.PasswordHash, 
			map => map.MapFrom(
				src => GetPasswordHashe(src.Password)));

		CreateMap<Funcionario, FuncionarioDTO>().ReverseMap();

		CreateMap<Funcionario, LoginResponseDTO>().ReverseMap();

		CreateMap<UpdateFuncionarioDTO, Funcionario>().ReverseMap();
	}

	private static string GetPasswordHashe(string password) => PasswordHasher.Hash(password);
}
