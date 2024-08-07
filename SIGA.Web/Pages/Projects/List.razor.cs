using Microsoft.AspNetCore.Components;
using MudBlazor;
using SIGA.Application.DTO.Projects;
using SIGA.Application.Handles.Interfaces;
using SIGA.Web.Components.Dialog;

namespace SIGA.Web.Pages.Projects;
/// TODO: Concluir páginas de projeto
public class ListProjectPage : ComponentBase
{
    #region Properties

    public bool IsBusy { get; set; } = false;
    public List<ProjectResponse> Projects { get; set; } = [];
    protected string? _searchString = null;
    protected MudDataGrid<ProjectResponse> _dataGrid = null!;

    #endregion

    #region Services

    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;

    [Inject]
    public IDialogService DialogService { get; set; } = null!;

    [Inject]
    public IProjectHandler Handler { get; set; } = null!;

    #endregion

    protected override async Task OnInitializedAsync()
    {
        IsBusy = true;
        try
        {
            var request = new PagedProjectRequest();
            var result = await Handler.GetAsync(request);
            if (result.IsSuccess)
                Projects = result.Data ?? [];
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

    public async Task<GridData<ProjectResponse>> LoadServerData(GridState<ProjectResponse> state)
    {
        var request = new PagedProjectRequest
        {
            SearchString = _searchString,
            PageNumber = state.Page + 1,
            PageSize = state.PageSize
        };

        var result = await Handler.GetAsync(request);

        var gridData = new GridData<ProjectResponse>
        {
            Items = result.Data ?? [],
            TotalItems = result.TotalCount
        };

        return gridData;
    }

    public Task OnSearch(string text)
    {
        _searchString = text;
        return _dataGrid.ReloadServerData();
    }

    public async Task OnDeleteButtonClickedAsync(int id, string title)
    {
        var parameters = new DialogParameters<DeleteRecordsDialog>
        {
            { x => x.ContentText, $"ATENÇÃO! O projeto {title} será excluído. Esta é uma ação irreversível! Deseja continuar?" },
            { x => x.ButtonText, "EXCLUIR" },
            { x => x.Color, Color.Error }
        };

        var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.ExtraSmall };

        var dialog = await DialogService.ShowAsync<DeleteRecordsDialog>("Delete", parameters, options);
        var result = await dialog.Result;

        if (!result!.Canceled)
            await OnDeleteAsync(id, title);
        else
            return;

        StateHasChanged();
        await _dataGrid.ReloadServerData();
    }

    public async Task OnDeleteAsync(int id, string title)
    {
        try
        {
            await Handler.DeleteAsync(id);
            Snackbar.Add($"Categoria {title} excluída", Severity.Success);
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
    }
}
