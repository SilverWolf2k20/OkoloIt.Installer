using System.Collections.Generic;
using System.Linq;

using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using OkoloIt.Installer.Template.Services;
using OkoloIt.Installer.Template.ViewModels.Pages;

namespace OkoloIt.Installer.Template.ViewModels;

internal sealed partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private NavigationService _navigationService;

    [ObservableProperty]
    private bool _isMaximizing;

    [ObservableProperty]
    private string _programName = "OkoloIt.Installer 2.0.0";

    public MainViewModel()
    {
        _navigationService  = new();

        // Метод Initialize используется из-за отсутствия DI контейнера.
        _navigationService.Initialize(CreatePages(_navigationService).ToList());
    }

    [RelayCommand]
    private void OnClose()
    {
        if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            desktop.Shutdown();
    }

    private static IEnumerable<ViewModelBase> CreatePages(NavigationService navigationService)
    {
        yield return new WelcomePageViewModel(navigationService);
        yield return new LicensePageViewModel(navigationService);
        yield return new InstallationModePageViewModel(navigationService);
        yield return new DesignationFolderPageViewModel(navigationService);
        yield return new InstallingPageViewModel(navigationService);
        yield return new InstalationCompletePageViewModel(navigationService);
    }
}
