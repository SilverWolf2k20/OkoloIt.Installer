using System;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OkoloIt.Installer.Template.Services;

internal sealed class InstallationVerificationService
{
    public bool CheckForAbsenceOfRunningProgram(string processName)
    {
        try {
            Process[] process = Process.GetProcessesByName("Product tree");
            return process.Any();
        }
        catch {
            return false;
        }
    }

    public async Task<bool> CheckServerConnectionAsync()
    {
        try {
            await Task.CompletedTask;

            return true;
        }
        catch {
            return false;
        }
    }

    public async Task<bool> CheckIfRequiredRuntimeVersionIsAvailableAsync()
    {
        try {
            return await Task.Run(() => {
                ProcessStartInfo startInfo = new("dotnet", "--list-runtimes");
                startInfo.CreateNoWindow = true;
                startInfo.UseShellExecute = false;
                startInfo.RedirectStandardOutput = true;

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

    private int GetRuntimeNumber(string source)
    {
        var groups = Regex.Match(source, @"NETCore\.App.((\d).\d.\d+)").Groups;
        _ = int.TryParse(groups[2].Value, out int version);

        return version;
    }
}
