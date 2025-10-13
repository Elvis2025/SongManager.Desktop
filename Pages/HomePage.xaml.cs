using SongManager.Desktop.Attributes;

namespace SongManager.Desktop.Pages
{
    [RegisterAsRoute]
    public partial class HomePage : BaseContentPage<HomePageModel>
    {
        private readonly HomePageModel basePageModel;

        public HomePage(HomePageModel basePageModel) : base(basePageModel)
        {
            InitializeComponent();
            this.basePageModel = basePageModel;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            basePageModel.InsertSongsListCommand.Execute(null);
        }
    }
}