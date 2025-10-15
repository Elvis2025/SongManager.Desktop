namespace SongManager.Desktop.Pages.Singers;
[RegisterAsRoute]
public partial class CreateSingersPage : BaseContentPage<CreateSingersPageModel>
{
    private readonly CreateSingersPageModel basePageModel;

    public CreateSingersPage(CreateSingersPageModel basePageModel) : base(basePageModel)
    {
        InitializeComponent();
        this.basePageModel = basePageModel;
    }

    private void GenderChange(object sender, EventArgs e)
    {
        basePageModel?.GenderSelected();
    }
}