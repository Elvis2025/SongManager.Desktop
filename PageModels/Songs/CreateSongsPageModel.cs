
using SongManager.Desktop.Pages.Modals;

namespace SongManager.Desktop.PageModels;
[RegisterPageModel]
public partial class CreateSongsPageModel : BasePageModel
{
    #region Oberservable Properties

    [ObservableProperty]
    private SongsDto? song = new();

    #endregion

    public Action<SongsDto>? OnSaveSong;

    
    [RelayCommand]
    public async Task SaveSongAsync()
    {
        
        try
        {
            OnSaveSong?.Invoke(Song!);
        }
        catch (Exception ex)
        {
            await ErrorAlert("Error", $"Failed to save song: {ex.Message}");
        }
    }


}
