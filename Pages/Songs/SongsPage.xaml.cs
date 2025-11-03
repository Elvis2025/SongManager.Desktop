namespace SongManager.Desktop.Pages.Songs;

public partial class SongsPage : BaseContentPage<SongsPageModel>
{
    private readonly SongsPageModel basePageModel;

    public SongsPage(SongsPageModel basePageModel) : base(basePageModel)
    {
        InitializeComponent();
        this.basePageModel = basePageModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        basePageModel.Init();
    }


    private void FilterSongsBySong(object sender, TextChangedEventArgs e)
    {

        FilterSongs();
    }

    private void FilterSongs()
    {
        var findSong = txtSong.Text ?? string.Empty;


        var findSongBysinger = pkSingers.SelectedItem as SingersDto;
        var allSongs = (findSongBysinger is null || findSongBysinger.Id == -1) && string.IsNullOrWhiteSpace(findSong);

        if (allSongs)
        {
            basePageModel.Songs = basePageModel.SongsList!.FormatterSongsRows();
            return;
        }

        if (string.IsNullOrWhiteSpace(findSong) && findSongBysinger!.Id >= 0)
        {
            basePageModel.Songs = basePageModel.SongsList?.Where(k => k.SingerId == findSongBysinger!.Id)
                                                                 .OrderBy(x => x.SingerName)
                                                                 .ToObservableCollection()
                                                                 .FormatterSongsRows();
            return;
        }
        if (!string.IsNullOrWhiteSpace(findSong) && findSongBysinger!.Id < 0)
        {
            basePageModel.Songs = basePageModel.SongsList?.Where(k => k.SongName.Contains(findSong, StringComparison.OrdinalIgnoreCase))
                                                          .OrderBy(x => x.SingerName)
                                                          .ToObservableCollection()
                                                          .FormatterSongsRows();
            return;
        }

        basePageModel.Songs = basePageModel.SongsList?.Where(k => k.SongName.Contains(findSong, StringComparison.OrdinalIgnoreCase) && k.SingerId == findSongBysinger!.Id)
                                                      .OrderBy(x => x.SingerName)
                                                      .ToObservableCollection()
                                                      .FormatterSongsRows();
    }
    private void FilterSongsBySinger(object sender, EventArgs e)
    {
        FilterSongs();
    }
}