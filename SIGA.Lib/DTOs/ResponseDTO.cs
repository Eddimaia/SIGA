using System.Text.Json.Serialization;

namespace SIGA.Lib.DTOs;
public class ResponseDTO<T> where T : class
{
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public T? Data { get; private set; } = default;

	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public List<string>? Erros { get; private set; } = default;

	public ResponseDTO(T data, List<string> erros)
	{
		Data = data;
		Erros = erros;
	}

	public ResponseDTO(List<string> erros) => Erros = erros;
	public ResponseDTO(T data) => Data = data;
	public ResponseDTO(string erro) => Erros = new List<string> { erro };

	public static SuccessResponse ReturnSucess(string message)
	{
		return new SuccessResponse(message);
	}
	public class SuccessResponse
	{
		public string Message { get; set; }

		public SuccessResponse(string message)
		{
			Message = message;
		}
	}
}
