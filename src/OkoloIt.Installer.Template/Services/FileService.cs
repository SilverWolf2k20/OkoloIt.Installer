using Avalonia;
using Avalonia.Platform.Storage;

using OkoloIt.Installer.Template.Extensions;

using System.Linq;
using System.Threading.Tasks;

namespace OkoloIt.Installer.Template.Services;

/// <summary>
/// Сервис взаимодействия с файловыми диалогами.
/// </summary>
internal class FileService
{
    private IStorageProvider? _storageProvider;

    /// <summary>
    /// Инициализирует сервис для работы с провайдером хранилища.
    /// </summary>
    internal void Initialize()
    {
        _storageProvider = Application.Current?.GetTopLevel().StorageProvider;
    }

    /// <summary>
    /// Асинхронно отображает диалог выбора папки для открытия.
    /// </summary>
    /// <returns>Объект папки.</returns>
    internal async Task<IStorageFolder?> OpenFolderAsync()
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
