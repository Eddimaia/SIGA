using AutoMapper;
using SecureIdentity.Password;
using SIGA.Domain.DTOs.Funcionario;
using SIGA.Domain.DTOs.Usuario;
using SIGA.Domain.Entities;

namespace SIGA.Domain.Mappings;
public class ContaMappingProfile : Profile
{
	public ContaMappingProfile()
	{

		CreateMap<Funcionario, FuncionarioDTO>().ReverseMap();

		CreateMap<Funcionario, LoginResponseDTO>().ReverseMap();

		CreateMap<UpdateFuncionarioDTO, Funcionario>().ReverseMap();
	}

	private static string GetPasswordHashe(string password) => PasswordHasher.Hash(password);
}
