using System;

using Avalonia;

namespace OkoloIt.Installer.Template;

/// <summary>
/// Точка запуска программы.
/// </summary>
internal class Program
{
    /// <summary>
    /// Запускает программу с переданными аргументами.
    /// </summary>
    /// <param name="args"></param>
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);

    /// <summary>
    /// Собирает и возвращает приложение.
    /// </summary>
    /// <returns>Собранное приложение.</returns>
    private static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
}
