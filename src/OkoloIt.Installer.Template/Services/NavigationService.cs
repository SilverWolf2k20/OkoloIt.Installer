using System;
using System.Collections.Generic;
using System.Linq;

using CommunityToolkit.Mvvm.ComponentModel;

using OkoloIt.Installer.Template.ViewModels;

namespace OkoloIt.Installer.Template.Services;

/// <summary>
/// Сервис навигации по страницам.
/// </summary>
internal partial class NavigationService() : ObservableObject
{
    private IReadOnlyCollection<ViewModelBase> _pages = [];

    [ObservableProperty]
    private ViewModelBase _currentPage = default!;

    /// <summary>
    /// Инициализирует сервис навигации и устанавливает по умолчание первую страницу.
    /// </summary>
    /// <param name="pages">Список страниц для навигации.</param>
    internal void Initialize(IReadOnlyCollection<ViewModelBase> pages)
    {
        _pages = pages;
        CurrentPage = _pages.First();
    }

    /// <summary>
    /// Переходит на указанную страницу по ее типу.
    /// </summary>
    /// <typeparam name="TViewModel">Тип целевой страницы.</typeparam>
    internal void NavigateTo<TViewModel>() where TViewModel : ViewModelBase
    {
        NavigateTo(typeof(TViewModel));
    }

    /// <summary>
    /// Переходит на указанную страницу по ее типу.
    /// </summary>
    /// <param name="viewModelType">Тип целевой страницы.</param>
    internal void NavigateTo(Type viewModelType)
    {
        ViewModelBase viewModel = _pages.First(x => x.GetType() == viewModelType);
        CurrentPage = viewModel;
    }
}
