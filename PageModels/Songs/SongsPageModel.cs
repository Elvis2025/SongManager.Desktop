using SongManager.Desktop.Constants;
using SongManager.Desktop.Models;
using SongManager.Desktop.Pages.Singers;
using SongManager.Desktop.Pages.Songs;

namespace SongManager.Desktop.PageModels;
[RegisterPageModel]
public partial class SongsPageModel : BasePageModel
{
    private readonly IRepository<Songs> songRepository;
    [ObservableProperty]
    private ObservableCollection<SongsDto>? songsList;
    public SongsPageModel(IRepository<Songs> songRepository)
    {
        this.songRepository = songRepository;
        Init();
    }

    public void Init()
    {
        Task.Run(async () =>
        {
            await FindAllSongsAsync();
        });
    }
    public async Task FindAllSongsAsync()
    {
        if (IsBusy) return;
        IsBusy = true;
        try
        {
            var songs = await songRepository.GetAllAsync();
            SongsList = new(songs.Map<SongsDto>());
            foreach (var (song, i) in SongsList.Select((value, i) => (value, i)))
            {
                if ((i % 2) == 0)
                {
                    song.HexColor = Color.FromArgb("#FFFFFF");
                    continue;
                }
                song.HexColor = Color.FromArgb("#E1E1E1");
            }
        }
        catch (Exception ex)
        {
            await ErrorAlert("Error", $"Failed to load songs: {ex.Message}");
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    public async Task CreateSong()
    {
        IsBusy = true;
        try
        {
            Preferences.Set(GlobalVariables.SongId, -1);
            await PushRelativePageAsync<CreateSongsPage>();
        }
        catch (Exception ex)
        {
            await ErrorAlert("Error", $"Failed to creating singers: {ex.Message}");
        }
        finally
        {
            IsBusy = false;
        }
    }


    [RelayCommand]
    public async Task EditSong(SongsDto singerDto)
    {
        IsBusy = true;
        try
        {
            if (singerDto is null || singerDto!.Id < 0) return;
            Preferences.Set(GlobalVariables.SingerId, singerDto!.Id);
            await PushModalAsync<CreateSingersPage>();
        }
        catch (Exception ex)
        {
            await ErrorAlert("Error", $"Failed to creating singers: {ex.Message}");
        }
        finally
        {
            IsBusy = false;
            CurrentSingerDto = new();
        }
    }

    [RelayCommand]
    public async Task DeleteSong(SongsDto songDto)
    {
        IsBusy = true;
        try
        {
            if (songDto is null || songDto!.Id < 0) return;
            await songRepository.DeleteAsync(songDto.Songs);
            Init();
        }
        catch (Exception ex)
        {
            await ErrorAlert("Error", $"Failed to creating singers: {ex.Message}");
        }
        finally
        {
            IsBusy = false;
            CurrentSingerDto = new();
        }
    }

}
