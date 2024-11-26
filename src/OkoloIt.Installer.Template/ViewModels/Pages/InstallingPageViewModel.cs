using CommunityToolkit.Mvvm.Input;

using OkoloIt.Installer.Template.Services;

namespace OkoloIt.Installer.Template.ViewModels.Pages;

internal sealed partial class InstallingPageViewModel(NavigationService navigationService) : ViewModelBase
{
    private readonly NavigationService _navigationService = navigationService;

    [RelayCommand]
    private void OnNextPage()
    {
        _navigationService.NavigateTo<InstalationCompletePageViewModel>();
    }
}
