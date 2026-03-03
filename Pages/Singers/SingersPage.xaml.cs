namespace SongManager.Desktop.Pages.Singers;
[RegisterAsRoute]
public partial class SingersPage : BaseContentPage<SingersPageModel>
{
    private readonly SingersPageModel basePageModel;

    public SingersPage(SingersPageModel basePageModel) : base(basePageModel)
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
            StatsCard.Opacity = 0;
            SingersCollection.Opacity = 0;
            BottomNav.Opacity = 0;
            await HeroCard.FadeTo(1, 220, Easing.CubicOut);
            await HeroCard.TranslateTo(0, 0, 220, Easing.CubicOut);
            await StatsCard.FadeTo(1, 200, Easing.CubicOut);
            await SingersCollection.FadeTo(1, 280, Easing.CubicOut);
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
}
