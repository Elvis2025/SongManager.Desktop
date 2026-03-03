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
        _ = AnimateEntranceAsync();
    }

    private async Task AnimateEntranceAsync()
    {
        try
        {
            HeroCard.Opacity = 0;
            HeroCard.TranslationY = -12;
            StatsCard1.Opacity = 0;
            StatsCard2.Opacity = 0;
            StatsCard3.Opacity = 0;
            FilterCard.Opacity = 0;
            SongsCollection.Opacity = 0;
            BottomNav.Opacity = 0;
            await HeroCard.FadeTo(1, 220, Easing.CubicOut);
            await HeroCard.TranslateTo(0, 0, 220, Easing.CubicOut);
            await Task.WhenAll(
                StatsCard1.FadeTo(1, 180, Easing.CubicOut),
                StatsCard2.FadeTo(1, 240, Easing.CubicOut),
                StatsCard3.FadeTo(1, 300, Easing.CubicOut));
            await FilterCard.FadeTo(1, 180, Easing.CubicOut);
            await SongsCollection.FadeTo(1, 260, Easing.CubicOut);
            await BottomNav.FadeTo(1, 180, Easing.CubicOut);
        }
        catch
        {
            // Evita crash por animación durante cambio rápido de página.
        }
    }

    private async void GoSongs_Clicked(object sender, EventArgs e) => await Shell.Current.GoToAsync("//SongsPage");
    private async void GoSingers_Clicked(object sender, EventArgs e) => await Shell.Current.GoToAsync("//SingersPage");
    private async void GoUsers_Clicked(object sender, EventArgs e) => await Shell.Current.GoToAsync("//UserPage");

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
            basePageModel.Songs = basePageModel.SongsList?.Where(k => k.SingerId == findSongBysinger.Id)
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

        basePageModel.Songs = basePageModel.SongsList?.Where(k => k.SongName.Contains(findSong, StringComparison.OrdinalIgnoreCase) && k.SingerId == findSongBysinger.Id)
                                                      .OrderBy(x => x.SingerName)
                                                      .ToObservableCollection()
                                                      .FormatterSongsRows();
    }

    private void FilterSongsBySinger(object sender, EventArgs e)
    {
        FilterSongs();
    }
}
