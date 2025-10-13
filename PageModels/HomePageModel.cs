using CommunityToolkit.Mvvm.Input;
using SongManager.Desktop.Attributes;
using SongManager.Desktop.DTOs;
using SongManager.Desktop.Extensions;
using SongManager.Desktop.Models;
using SongManager.Desktop.Repositories.SQLite;
using SongManager.Desktop.UsesCases;
using System.Collections.ObjectModel;

namespace SongManager.Desktop.PageModels;
[RegisterPageModel]
public partial class HomePageModel : BasePageModel
{
    private readonly IRepository<SongsList> songListRepository;
    [ObservableProperty]
    private ObservableCollection<SongsListDto>? songsList;
    public HomePageModel(IRepository<SongsList> songListRepository)
    {
        this.songListRepository = songListRepository;
        Init();
    }

    public void Init()
    {
        Task.Run(async () =>
        await GetAllSongsAsync()
        );
    }
    public async Task<List<SongsList>> GetAllSongsAsync()
    {
        IsBusy = true;
        try
        {
            var songs = await songListRepository.GetAllAsync();
      
            var coll = songs.Map<SongsListDto>();
            if (coll is null || !coll.Any()) return new();

            SongsList = new(coll);
            return songs.ToList();
        }
        catch (Exception ex)
        {
            await ErrorAlert("Error", $"Failed to load songs: {ex.Message}");
            return new List<SongsList>();
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    public async Task InsertSongsListAsync()
    {
        await TestData.InsertSongsListAsync();

        var songs = await songListRepository.GetAllAsync();

        var coll = songs.Map<SongsListDto>();
        if (coll is null || !coll.Any()) return;

        SongsList = new(coll);
    }
}
