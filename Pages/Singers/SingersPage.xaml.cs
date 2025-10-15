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
    }
}