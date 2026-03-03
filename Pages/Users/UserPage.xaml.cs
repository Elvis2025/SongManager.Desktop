namespace SongManager.Desktop.Pages.Users;
[RegisterAsRoute]
public partial class UserPage : BaseContentPage<UserPageModel>
{
    public UserPage(UserPageModel basePageModel) : base(basePageModel)
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _ = AnimateEntranceAsync();
    }

    private async Task AnimateEntranceAsync()
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
}
