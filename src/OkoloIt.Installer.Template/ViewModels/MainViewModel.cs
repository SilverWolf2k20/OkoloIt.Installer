using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using OkoloIt.Installer.Template.ViewModels.Pages;

namespace OkoloIt.Installer.Template.ViewModels;

internal sealed partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private ViewModelBase _currentPage = new WelcomePageViewModel();

    [ObservableProperty]
    private bool _isMaximizing;

    [ObservableProperty]
    private string _programName = "OkoloIt.Installer 2.0.0";

    [RelayCommand]
    private void OnClose()
    {
        if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            desktop.Shutdown();
    }
}
