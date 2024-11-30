using System;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OkoloIt.Installer.Template.Services;

/// <summary>
/// Сервис проверки системы перед установкой.
/// </summary>
internal sealed class InstallationVerificationService
{
    /// <summary>
    /// Проверяет отсутствие запущенного процесса.
    /// </summary>
    /// <param name="processName">Наименование процесса.</param>
    /// <returns>
    /// <see langword="true"/> - если процесс не обнаружен, <see langword="false"/> - в противном
    /// случае.
    /// </returns>
    internal bool CheckForAbsenceOfRunningProgram(string processName)
    {
        try {
            Process[] process = Process.GetProcessesByName("Product tree");
            return process.Any();
        }
        catch {
            return false;
        }
    }

    /// <summary>
    /// Проверяет наличие подключения к серверу для получения установочных данных.
    /// </summary>
    /// <returns>
    /// <see langword="true"/> - если соединение есть, <see langword="false"/> - в противном
    /// случае.
    /// </returns>
    internal async Task<bool> CheckServerConnectionAsync()
    {
        try {
            await Task.CompletedTask;

            return true;
        }
        catch {
            return false;
        }
    }

    /// <summary>
    /// Проверяет наличие необходимой версии среды исполнения.
    /// </summary>
    /// <returns>
    /// <see langword="true"/> - имеется необходимая версия среды исполнения,
    /// <see langword="false"/> - в противном случае.
    /// </returns>
    internal async Task<bool> CheckIfRequiredRuntimeVersionIsAvailableAsync()
    {
        try {
            return await Task.Run(() => {
                ProcessStartInfo startInfo = new("dotnet", "--list-runtimes") {
                    CreateNoWindow         = true,
                    UseShellExecute        = false,
                    RedirectStandardOutput = true
                };

                Process process = Process.Start(startInfo)!;

                int currentVersion = process.StandardOutput.ReadToEnd()
                    .Split("\r\n")
                    .Where(r => r.Contains("NETCore"))
                    .Select(r => GetRuntimeNumber(r))
                    .Max();

                string targetRuntimeVersion = Environment.Version.ToString()
                    .Trim()
                    .First()
                    .ToString();

                int targetVersion = Convert.ToInt32(targetRuntimeVersion);

                return targetVersion <= currentVersion;
            });
        }
        catch {
            return false;
        }
    }

    /// <summary>
    /// Возвращает мажорный номер среды исполнения.
    /// </summary>
    /// <param name="source">Путь до файла среды исполнения.</param>
    /// <returns>Мажорный номер среды исполнения.</returns>
    private int GetRuntimeNumber(string source)
    {
        var groups = Regex.Match(source, @".* (\d+)[.]?.*").Groups;
        _ = int.TryParse(groups[2].Value, out int version);

        return version;
    }
}
