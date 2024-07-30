using Microsoft.JSInterop;

namespace SIGA.IoC.Web.Services;

public class SessionStorageService
{
    private readonly IJSRuntime _jsRuntime;

    public SessionStorageService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task SetItemAsync(string key, string value)
    {
        await _jsRuntime.InvokeVoidAsync("sessionStorageHelper.setItem", key, value);
    }

    public async Task<string> GetItemAsync(string key)
    {
        return await _jsRuntime.InvokeAsync<string>("sessionStorageHelper.getItem", key);
    }

    public async Task RemoveItemAsync(string key)
    {
        await _jsRuntime.InvokeVoidAsync("sessionStorageHelper.removeItem", key);
    }

    public async Task ClearAsync()
    {
        await _jsRuntime.InvokeVoidAsync("sessionStorageHelper.clear");
    }
}
