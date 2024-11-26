using System;
using System.Collections.Generic;
using System.Linq;

using CommunityToolkit.Mvvm.ComponentModel;

using OkoloIt.Installer.Template.ViewModels;

namespace OkoloIt.Installer.Template.Services;

internal partial class NavigationService() : ObservableObject
{
    private IReadOnlyCollection<ViewModelBase> _pages = [];

    [ObservableProperty]
    public ViewModelBase _currentPage = default!;

    public void Initialize(IReadOnlyCollection<ViewModelBase> pages)
    {
        _pages = pages;
        CurrentPage = _pages.First();
    }

    public void NavigateTo<TViewModel>() where TViewModel : ViewModelBase
    {
        NavigateTo(typeof(TViewModel));
    }

    public void NavigateTo(Type viewModelType)
    {
        ViewModelBase viewModel = _pages.First(x => x.GetType() == viewModelType);
        CurrentPage = viewModel;
    }
}

