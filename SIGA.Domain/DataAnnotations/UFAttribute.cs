using System.ComponentModel.DataAnnotations;

namespace SIGA.Domain.DataAnnotations;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
public class UFAttribute : ValidationAttribute
{
	public static string[] UFValues => new string[] 
	{ 
		"RO", "AC", "AM", "RR", "PA", "AP", "TO",
		"MA", "PI", "CE", "RN", "PB", "PE", "AL", 
		"SE", "BA", "MG", "ES", "RJ", "SP", "PR", 
		"SC", "RS", "MS", "MT", "GO", "DF" 
	};
	public override bool IsValid(object? value)
	{
		if (value == null)
			return true;

		return UFValues.Contains(value.ToString().ToUpperInvariant());
	}
	public override string FormatErrorMessage(string name)
	{
		return $"UF deve ser uma das UFs válidas -> {string.Join(", ",UFValues)}";
	}
}
