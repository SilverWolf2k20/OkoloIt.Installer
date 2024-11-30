using System;
using System.IO;

using Avalonia.Platform;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using OkoloIt.Installer.Template.Services;

namespace OkoloIt.Installer.Template.ViewModels.Pages;

internal sealed partial class LicensePageViewModel: ViewModelBase
{
    private readonly NavigationService _navigationService;

    [ObservableProperty]
    private string _licenseText;

    [ObservableProperty]
    private bool _isAccepted;

    internal LicensePageViewModel(NavigationService navigationService)
    {
        _navigationService = navigationService;

        var stream = AssetLoader.Open(new Uri("avares://OkoloIt.Installer.Template/Assets/license.txt"));
        using StreamReader reader = new(stream);
        _licenseText = reader.ReadToEnd();
    }

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
