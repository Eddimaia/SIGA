using System.Text.Json.Serialization;

namespace SIGA.Application.DTO.Common;
public class Response<TEntityResponse>
{
    private readonly int _code;

    [JsonConstructor]
    public Response()
        => _code = 200;

    public Response(
        TEntityResponse? data,
        int code = 200,
        string? message = null)
    {
        Data = data;
        Message = message;
        _code = code;
    }

    public TEntityResponse? Data { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Message { get; set; }
    [JsonIgnore]
    public int Code => _code;

    [JsonIgnore]
    public bool IsSuccess
        => _code is >= 200 and <= 299;
}
