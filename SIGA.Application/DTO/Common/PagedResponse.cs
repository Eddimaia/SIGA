using System.Text.Json.Serialization;

namespace SIGA.Application.DTO.Common;
public class PagedResponse<TData> : Response<TData>
{
    [JsonConstructor]
    public PagedResponse(
        TData? data,
        int totalCount,
        int currentPage = 1,
        int pageSize = 10)
        : base(data)
    {
        Data = data;
        TotalCount = totalCount;
        CurrentPage = currentPage;
        PageSize = pageSize;
    }

    public PagedResponse(
        TData? data,
        int code = 200,
        string? message = null)
        : base(data, code, message)
    {
    }

    public int CurrentPage { get; set; }
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
    public int PageSize { get; set; } = 10;
    public int TotalCount { get; set; }
}