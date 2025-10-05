using SongManager.Desktop.Models;
using SongManager.Desktop.PageModels;

namespace SongManager.Desktop.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }
    }
}