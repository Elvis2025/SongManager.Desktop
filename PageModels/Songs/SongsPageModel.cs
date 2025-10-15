using SongManager.Desktop.Models;

namespace SongManager.Desktop.PageModels;
[RegisterPageModel]
public partial class SongsPageModel : BasePageModel
{
    private readonly IRepository<SongsLists> songListRepository;
    [ObservableProperty]
    private ObservableCollection<SongsListsDto>? songsList;
    public SongsPageModel(IRepository<SongsLists> songListRepository)
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
    public async Task<List<SongsLists>> GetAllSongsAsync()
    {
        IsBusy = true;
        try
        {
            var songs = await songListRepository.GetAllAsync();

            var coll = songs.Map<SongsListsDto>();
            if (coll is null || !coll.Any()) return new();

            SongsList = new(coll);
            return songs.ToList();
        }
        catch (Exception ex)
        {
            await ErrorAlert("Error", $"Failed to load songs: {ex.Message}");
            return new List<SongsLists>();
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

        var coll = songs.Map<SongsListsDto>();
        if (coll is null || !coll.Any()) return;

        SongsList = new(coll);
    }
}
