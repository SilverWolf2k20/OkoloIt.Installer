using System.Threading.Tasks;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using OkoloIt.Installer.Template.Services;

namespace OkoloIt.Installer.Template.ViewModels.Pages;

internal sealed partial class InstallingPageViewModel(NavigationService navigationService) : ViewModelBase
{
    private readonly NavigationService _navigationService = navigationService;
    private readonly InstallationService _installationService = new();

    [ObservableProperty]
    private string _message = string.Empty;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(BackPageCommand))]
    [NotifyCanExecuteChangedFor(nameof(CancelCommand))]
    private bool _isInstalling = true;

    [RelayCommand]
    private async Task OnLoaded()
    {
        _installationService.Install();
        await Task.Delay(2000);
        IsInstalling = false;

        _navigationService.NavigateTo<InstalationCompletePageViewModel>();
    }

    [RelayCommand(CanExecute = nameof(CanGoToBackPage))]
    private void OnBackPage()
    {
        _navigationService.NavigateTo<DesignationFolderPageViewModel>();
    }

    [RelayCommand(CanExecute = nameof(CanCancel))]
    private void OnCancel()
    {
        _installationService.Cancel();

        IsInstalling = false;
    }

    private bool CanGoToBackPage()
    {
        return IsInstalling == false;
    }

    private bool CanCancel()
    {
        return IsInstalling == true;
    }
}
