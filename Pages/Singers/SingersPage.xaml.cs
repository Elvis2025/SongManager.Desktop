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
        PageRoot.Opacity = 0;
        PageRoot.TranslationY = 16;
        await Task.WhenAll(
            PageRoot.FadeTo(1, 320, Easing.CubicOut),
            PageRoot.TranslateTo(0, 0, 320, Easing.CubicOut));
    }
}
