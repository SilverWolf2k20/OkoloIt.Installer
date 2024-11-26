using CommunityToolkit.Mvvm.Input;

using OkoloIt.Installer.Template.Services;

namespace OkoloIt.Installer.Template.ViewModels.Pages;

internal sealed partial class LicensePageViewModel(NavigationService navigationService) : ViewModelBase
{
    private readonly NavigationService _navigationService = navigationService;

    [RelayCommand]
    private void OnNextPage()
    {
        _navigationService.NavigateTo<InstallationModePageViewModel>();
    }

    [RelayCommand]
    private void OnBackPage()
    {
        _navigationService.NavigateTo<WelcomePageViewModel>();
    }
}
