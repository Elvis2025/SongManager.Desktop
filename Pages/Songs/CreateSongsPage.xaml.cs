namespace SongManager.Desktop.Pages.Songs;
[RegisterAsRoute]
public partial class CreateSongsPage : BaseContentPage<CreateSongsPageModel>
{
    public CreateSongsPage(CreateSongsPageModel basePageModel) : base(basePageModel)
    {
        InitializeComponent();
    }
}