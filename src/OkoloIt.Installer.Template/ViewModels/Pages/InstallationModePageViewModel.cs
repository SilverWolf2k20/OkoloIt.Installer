using System;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using OkoloIt.Installer.Template.Services;

namespace OkoloIt.Installer.Template.ViewModels.Pages;

internal sealed partial class InstallationModePageViewModel(NavigationService navigationService) : ViewModelBase
{
    private readonly NavigationService _navigationService = navigationService;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(NextPageCommand))]
    private bool _canInstall;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(NextPageCommand))]
    private bool _canUpdate;

    [RelayCommand(CanExecute = nameof(CanNext))]
    private void OnNextPage()
    {
        _navigationService.NavigateTo<DesignationFolderPageViewModel>();
    }

    [RelayCommand]
    private void OnBackPage()
    {
        _navigationService.NavigateTo<LicensePageViewModel>();
    }

    private bool CanNext()
    {
        return CanInstall || CanUpdate;
    }
}
