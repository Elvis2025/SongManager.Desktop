namespace SongManager.Desktop.Pages.Users;
[RegisterAsRoute]
public partial class UserPage : BaseContentPage<UserPageModel>
{
    private readonly UserPageModel basePageModel;

    public UserPage(UserPageModel basePageModel) : base(basePageModel)
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
            UsersInfoGrid.Opacity = 0;
            BottomCard.Opacity = 0;
            HeroCard.TranslationY = -10;
            await HeroCard.FadeTo(1, 220, Easing.CubicOut);
            await HeroCard.TranslateTo(0, 0, 220, Easing.CubicOut);
            await UsersInfoGrid.FadeTo(1, 260, Easing.CubicOut);
            await BottomCard.FadeTo(1, 220, Easing.CubicOut);
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
