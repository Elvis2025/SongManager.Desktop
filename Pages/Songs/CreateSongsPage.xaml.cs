using SongManager.Desktop.PageModels;

namespace SongManager.Desktop.Pages.Songs;
[RegisterAsRoute]
public partial class CreateSongsPage : ContentPage
{
    public CreateSongsPage(CreateSongsPageModel basePageModel)
    {
        InitializeComponent();
        BindingContext = basePageModel;
    }

    
}