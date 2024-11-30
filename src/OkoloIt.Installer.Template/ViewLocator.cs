using System;

using Avalonia.Controls;
using Avalonia.Controls.Templates;

using OkoloIt.Installer.Template.ViewModels;

namespace OkoloIt.Installer.Template;

/// <summary>
/// Механизм сопоставляющий классы моделей представлений с представлениями.
/// </summary>
internal sealed class ViewLocator : IDataTemplate
{
    /// <inheritdoc/>
    public Control? Build(object? data)
    {
        if (data is null)
            return null;

        var name = data.GetType().FullName!.Replace("ViewModel", "View", StringComparison.Ordinal);
        var type = Type.GetType(name);

        if (type is not null)
            return (Control)Activator.CreateInstance(type)!;

        return new TextBlock { Text = "Not Found: " + name };
    }

    /// <inheritdoc/>
    public bool Match(object? data)
    {
        return data is ViewModelBase;
    }
}
