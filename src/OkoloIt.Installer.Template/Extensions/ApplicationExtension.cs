using System;

using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;

namespace OkoloIt.Installer.Template.Extensions;

/// <summary>
/// Расширение для класса <see cref="Application"/>.
/// </summary>
internal static class ApplicationExtension
{
    /// <summary>
    /// Возвращает объект окна верхнего уровня окна.
    /// </summary>
    /// <param name="application">Объект приложения.</param>
    /// <returns>Объект окна верхнего уровня окна для текущей платформы.</returns>
    /// <exception cref="NullReferenceException">
    /// Возникает при отсутствии объекта окна верхнего уровня.
    /// </exception>
    /// <exception cref="NotSupportedException">
    /// Возникает при использовании на неподдерживаемой платформе.
    /// </exception>
    internal static TopLevel GetTopLevel(this Application application)
    {
        if (application.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop) {
            TopLevel? topLevel = TopLevel.GetTopLevel(desktop?.MainWindow);
            return topLevel ?? throw new NullReferenceException($"{topLevel} равен null!");
        }

        if (application.ApplicationLifetime is ISingleViewApplicationLifetime single) {
            TopLevel? topLevel = TopLevel.GetTopLevel(single?.MainView);
            return topLevel ?? throw new NullReferenceException($"{topLevel} равен null!");
        }

        throw new NotSupportedException("Данная платформа не поддерживается!");
    }
}
