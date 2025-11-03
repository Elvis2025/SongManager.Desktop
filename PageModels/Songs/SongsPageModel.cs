using SongManager.Desktop.Constants;
using SongManager.Desktop.DTOs;
using SongManager.Desktop.Models;
using SongManager.Desktop.Pages.Modals;
using SongManager.Desktop.Pages.Singers;
using SongManager.Desktop.Pages.Songs;

namespace SongManager.Desktop.PageModels;
[RegisterPageModel]
public partial class SongsPageModel : BasePageModel
{
    private readonly IRepository<Songs> songRepository;
    private readonly IRepository<Singers> singerRepository;
    [ObservableProperty]
    private ObservableCollection<SongsDto>? songsList;
    [ObservableProperty]
    private ObservableCollection<SongsDto>? songs;

    [ObservableProperty]
    private SongsDto? currentSong;

    [ObservableProperty]
    private ObservableCollection<SingersDto>? singersRepository;
    [ObservableProperty]
    private ObservableCollection<SingersDto>? singers;

    [ObservableProperty]
    private ObservableCollection<KeyDto>? currentKeys;

    public SongsPageModel(IRepository<Songs> songRepository, IRepository<Singers> singerRepository)
    {
        this.songRepository = songRepository;
        this.singerRepository = singerRepository;
        Init();
    }

    public void Init()
    {
        Task.Run(async () =>
        {
            await FindAllSongsAsync();
            await LoadSingersAsync();

        });
    }
    private async Task LoadSingersAsync()
    {
        try
        {
            var singers = await singerRepository.GetAllAsync();
            SingersRepository = new(singers.Map<SingersDto>());
            Singers = SingersRepository;
            Singers.Add(new()
            {
                Id = -1,
                FirstName = "Todos"
            });
        }
        catch (Exception ex)
        {
            await ErrorAlert("Error", $"Failed to load singers: {ex.Message}");
        }
    }
    private async Task FindAllSongsAsync()
    {
        if (IsBusy) return;
        IsBusy = true;
        try
        {
            var query = @$"SELECT
                              s.Id,
                              SingerId,
	                          (FirstName || ' ' || FirstSurname) AS SingerName,
	                          SongName,
	                          SongAuthor,
	                          Key,
							  Link,
							  Comment
                           FROM Songs s
                           INNER JOIN Singers q ON s.SingerId == q.Id";
            var songs = await songRepository.QueryAsync<SongsDto>(query);

            SongsList = songs.OrderBy(x => x.SingerName)
                             .ToObservableCollection()
                             .FormatterSongsRows();
            Songs = SongsList;

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

    private async Task SelectSinger()
    {
        try
        {
            if (SingersRepository == null || !SingersRepository.Any())
            {
                await WarningAlert("Alerta", "No puedes crear canciones. Para poder crear una canción, debe existir al menos un cantante.");
                return;
            }

            var selectModalPage = new SelectSingersModalPage(new()
            {
                AllSingers = SingersRepository,
                Singers = SingersRepository,
                CurrentSingersSelected = CurrentSingerDto ?? new(),
                OnSelectedSinger = async (itemSelected) =>
                {
                    CurrentSingerDto = itemSelected;
                    await PopModalAsync();
                    await SelectKey();
                }

            });
            await PushModalAsync(selectModalPage);
        }
        catch (Exception e)
        {
            await ErrorAlert("Song manager error", e.Message);
        }
    }

    public async Task SelectKey()
    {

        try
        {
            var selectModalPage = new SelectKeyModalPage(new()
            {
                CurrentKeysSelected = CurrentKeys ?? new(),
                OnSelectedKey = async (itemsSelected) =>
                {
                    CurrentKeys = itemsSelected;
                    await PopModalAsync();
                    await SaveChangesSong();
                },
                GoModalBack = async () =>
                {
                    await PopModalAsync();
                    await SelectSinger();
                }

            });
            await PushModalAsync(selectModalPage);
        }
        catch (Exception e)
        {
            await ErrorAlert("Song manager error", e.Message);
        }
    }

    public async Task SaveChangesSong()
    {
        try
        {
            var editingSong = GlobalVariables.GetSongId > 0;
            var selectModalPage = new CreateSongsPage(new()
            {
                Song = new()
                {
                    SingerId = CurrentSingerDto!.Id,
                    SingerName = CurrentSingerDto!.FullName,
                    Key = string.Join("/", CurrentKeys?.Select(x => x.Name) ?? Enumerable.Empty<string>()),
                    SongName = CurrentSong?.SongName ?? string.Empty,
                    Link = CurrentSong?.Link ?? string.Empty,
                    SongAuthor = CurrentSong?.SongAuthor ?? string.Empty,
                    Comment = CurrentSong?.Comment ?? string.Empty,
                },
                OnSaveSong = async (itemSelected) =>
                {
                    if (editingSong)
                    {
                        itemSelected.Id = GlobalVariables.GetSongId;
                        await songRepository.UpdateAsync(itemSelected.Songs);
                    }
                    else
                    {
                        await songRepository.InsertAsync(itemSelected.Songs);
                    }
                    await FindAllSongsAsync();
                    await PopModalAsync();

                },
                GoModalBack = async () =>
                {
                    await PopModalAsync();
                    await SelectKey();

                }

            });

            await PushModalAsync(selectModalPage);
        }
        catch (Exception e)
        {
            await ErrorAlert("Song manager error", e.Message);
        }
        finally
        {

        }
    }


    [RelayCommand]
    public async Task CreateSong()
    {
        IsBusy = true;
        try
        {
            ClearValues();
            Preferences.Set(GlobalVariables.SongId, -1);
            await SelectSinger();
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

    private void ClearValues()
    {
        CurrentSong = new();
        CurrentSingerDto = new();
        CurrentKeys = new();
    }

    [RelayCommand]
    public async Task EditSong(SongsDto song)
    {
        IsBusy = true;
        try
        {
            if (song is null || song!.Id < 0) return;
            CurrentSong = song;
            Preferences.Set(GlobalVariables.SongId, CurrentSong.Id);
            CurrentKeys = new(CurrentSong?.Keys!);
            CurrentSingerDto = SingersRepository?.FirstOrDefault(x => x.Id == song.SingerId);
            await SelectSinger();
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

    [RelayCommand]
    public async Task OpenLinkSong(string link)
    {
        try
        {
            if (string.IsNullOrEmpty(link)) return;

            await Launcher.OpenAsync(link);
        }
        catch (Exception ex)
        {
            await ErrorAlert("Error", $"No se pudo abrir YouTube: {ex.Message}");
        }

    }

    [RelayCommand]
    public async Task Refresh()
    {
        try
        {
            Init();
        }
        catch (Exception ex)
        {
            await ErrorAlert("Error", $"No se pudo abrir YouTube: {ex.Message}");
        }

    }


}
