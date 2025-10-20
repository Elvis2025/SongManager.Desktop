using SongManager.Desktop.PageModels;

namespace SongManager.Desktop.Pages.Songs;
[RegisterAsRoute]
public partial class CreateSongsPage : BaseContentPage<CreateSongsPageModel>
{
    private readonly CreateSongsPageModel basePageModel;
    private readonly IRepository<Models.Singers> singerRepository;


    public CreateSongsPage(CreateSongsPageModel basePageModel) : base(basePageModel)
    {
        InitializeComponent();
        this.basePageModel = basePageModel;
        this.singerRepository = singerRepository;
    }

    public void Init()
    {

    }

   
}