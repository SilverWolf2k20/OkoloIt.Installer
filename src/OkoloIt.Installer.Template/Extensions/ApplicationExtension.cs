using System;

using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;

namespace OkoloIt.Installer.Template.Extensions;

public static class ApplicationExtension
{
    public static TopLevel GetTopLevel(this Application application)
    {
        if (application.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop) {
            TopLevel? topLevel = TopLevel.GetTopLevel(desktop?.MainWindow);
            return topLevel ?? throw new ArgumentException("topLevel равен null!");
        }

        if (application.ApplicationLifetime is ISingleViewApplicationLifetime single) {
            TopLevel? topLevel = TopLevel.GetTopLevel(single?.MainView);
            return topLevel ?? throw new ArgumentException("topLevel равен null!");
        }

        throw new NotSupportedException("Данная платформа не поддерживается!");
    }
}


