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
        PageRoot.Opacity = 0;
        PageRoot.TranslationY = 16;
        await Task.WhenAll(
            PageRoot.FadeTo(1, 320, Easing.CubicOut),
            PageRoot.TranslateTo(0, 0, 320, Easing.CubicOut));
    }
}
