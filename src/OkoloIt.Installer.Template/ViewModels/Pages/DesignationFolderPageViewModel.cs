using System;
using System.Threading.Tasks;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using OkoloIt.Installer.Template.Services;

namespace OkoloIt.Installer.Template.ViewModels.Pages;

internal sealed partial class DesignationFolderPageViewModel : ViewModelBase
{
    private readonly NavigationService _navigationService;
    private readonly FileService _fileService = new();

    private readonly string _defaultFolderPath;

    [ObservableProperty]
    private string _folderPath = string.Empty;

    [ObservableProperty]
    private bool _canCreateShortcut;

    public DesignationFolderPageViewModel(NavigationService navigationService)
    {
        _navigationService = navigationService;

        _defaultFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
        _folderPath = _defaultFolderPath;
    }

    [RelayCommand]
    private void OnLoaded()
    {
        // Используется т.к. объект основного окна не успевает создаться.
        _fileService.Initialize();
    }

    [RelayCommand]
    private void OnNextPage()
    {
        _navigationService.NavigateTo<InstallingPageViewModel>();
    }

    [RelayCommand]
    private void OnBackPage()
    {
        _navigationService.NavigateTo<InstallationModePageViewModel>();
    }

    [RelayCommand]
    private async Task OnSelectFolder()
    {
        var storage = await _fileService.OpenFolderAsync();
        FolderPath = storage?.Path.LocalPath ?? FolderPath;
    }

    [RelayCommand]
    private void OnResetFolder()
    {
        FolderPath = _defaultFolderPath;
    }
}
