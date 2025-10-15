using SongManager.Desktop.Attributes;

namespace SongManager.Desktop.Pages
{
    [RegisterAsRoute]
    public partial class HomePage : BaseContentPage<HomePageModel>
    {

        public HomePage(HomePageModel basePageModel) : base(basePageModel)
        {
            InitializeComponent();
        }
        
    }
}