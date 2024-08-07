using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using SIGA.Application.DTO.Employee;
using SIGA.Application.DTO.Projects;
using SIGA.Application.Handles.Interfaces;
using SIGA.Web.Security.Interfaces;

namespace SIGA.Web.Pages.Projects;

public class CreatePage : ComponentBase
{
    public CreateProjectRequest InputModel { get; set; } = new();
    public List<EmployeeResponse> Employees { get; set; } = [];
    protected string? _searchString = null;
    protected int _coordinatorId;
    public bool IsBusy { get; set; } = false;


    [Inject]
    public IProjectHandler Handler { get; set; } = null!;

    [Inject]
    public IEmployeeHandler EmployeeHandler { get; set; } = null!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    [Inject]
    public ICustomAuthStateProvider AuthenticationStateProvider { get; set; } = null!;

    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        IsBusy = true;
        try
        {
            await LoadServerData();
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
        finally
        {
            IsBusy = false;
        }
    }

    public async Task LoadServerData()
    {
        IsBusy = true;

        var result = await EmployeeHandler.GetAllAsync();

        if (result.Data != null && result.Data.Any())
        {
            Employees.AddRange(result.Data);
        }

        IsBusy = false;
    }

    public async Task OnValidSubmitAsync()
    {
        IsBusy = true;

        try
        {
            InputModel.CoordinatorId = _coordinatorId == 0 ? null : _coordinatorId;
            var result = await Handler.CreateAsync(InputModel);

            if (result.IsSuccess)
            {
                Snackbar.Add(result.Message, Severity.Success);
                NavigationManager.NavigateTo("/projetos");
            }
            else
                Snackbar.Add(result.Message, Severity.Error);
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
        finally
        {
            IsBusy = false;
        }
    }

    public string GetMultiSelectionText(List<string> selectedValues)
        => string
        .Join(", ",
            Employees
            .Where(x => selectedValues
                .Contains(x.Id.ToString()))
            .Select(x => x.FullName));


    public async Task UploadFiles(IBrowserFile file)
    {
        try
        {
            if (file != null)
            {
                using var stream = file.OpenReadStream(maxAllowedSize: 10 * 1024 * 1024); // 10 MB max
                using var ms = new MemoryStream();
                await stream.CopyToAsync(ms);
                var bytes = ms.ToArray();
                InputModel.ImageBase64 = Convert.ToBase64String(bytes);
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
    }
}
