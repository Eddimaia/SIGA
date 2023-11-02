namespace SIGA.Lib.DTOs;
public class ResponseDTO<T> where T : class
{
    public T? Data { get; private set; } = default;
    public List<string> Erros { get; private set; } = new();

    public ResponseDTO(T data, List<string> erros)
    {
        Data = data;
        Erros = erros;
    }

    public ResponseDTO(List<string> erros) => Erros = erros;
    public ResponseDTO(T data) => Data = data;
    public ResponseDTO(string erro) => Erros.Add(erro);
}
