using System.Threading.Tasks;

using CommunityToolkit.Mvvm.Input;

using OkoloIt.Installer.Template.Services;

namespace OkoloIt.Installer.Template.ViewModels.Pages;

internal sealed partial class WelcomePageViewModel(
    NavigationService navigationService)
    : ViewModelBase
{
    private readonly NavigationService _navigationService = navigationService;
    private readonly InstallationVerificationService _verificationService = new();

    [RelayCommand]
    private async Task OnLoaded()
    {
        bool i = await _verificationService.CheckIfRequiredRuntimeVersionIsAvailableAsync();
    }

    [RelayCommand]
    private void OnNextPage()
    {
        _navigationService.NavigateTo<LicensePageViewModel>();
    }
}
