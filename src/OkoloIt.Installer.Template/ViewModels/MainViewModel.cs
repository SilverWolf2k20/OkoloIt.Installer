using CommunityToolkit.Mvvm.ComponentModel;

namespace OkoloIt.Installer.Template.ViewModels;

internal sealed partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    public string title = "Заголовок";
}
