using CommunityToolkit.Mvvm.ComponentModel;

namespace SongManager.Desktop.PageModels;

public abstract partial class BasePageModel : ObservableObject
{
    [ObservableProperty]
    private bool isBusy;
}
