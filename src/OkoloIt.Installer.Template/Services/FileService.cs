using Avalonia;
using Avalonia.Platform.Storage;

using OkoloIt.Installer.Template.Extensions;

using System.Linq;
using System.Threading.Tasks;

namespace OkoloIt.Installer.Template.Services;

internal class FileService
{
    private IStorageProvider? _storageProvider;

    public void Initialize()
    {
        _storageProvider = Application.Current?.GetTopLevel().StorageProvider;
    }

    public async Task<IStorageFolder?> OpenFolderAsync()
    {
        if (_storageProvider is null)
            return default;

        var options = new FolderPickerOpenOptions() {
            Title = "Выбор каталога для установки программы",
            AllowMultiple = false,
        };

        var folders = await _storageProvider.OpenFolderPickerAsync(options);

        return folders.FirstOrDefault();
    }
}
