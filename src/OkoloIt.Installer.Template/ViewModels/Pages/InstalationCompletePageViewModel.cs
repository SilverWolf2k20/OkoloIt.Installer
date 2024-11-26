using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace OkoloIt.Installer.Template.ViewModels.Pages;

internal sealed partial class InstalationCompletePageViewModel : ViewModelBase
{
    [ObservableProperty]
    private bool _canRunProgram;

    [RelayCommand]
    private void OnClose()
    {
        if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            desktop.Shutdown();
    }
}
