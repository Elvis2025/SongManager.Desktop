using SongManager.Desktop.PageModels.Modals;

namespace SongManager.Desktop.Pages.Modals;

public partial class SelectSingersModalPage : ContentPage
{
    private readonly SelectSingersModalPageModel modalPage;

    public SelectSingersModalPage(SelectSingersModalPageModel modalPage)
	{
		InitializeComponent();
		BindingContext = modalPage;
        this.modalPage = modalPage;
    }

    private void FindSinger(object sender, TextChangedEventArgs e)
    {
        var currentKey = e.NewTextValue ?? string.Empty;

        modalPage.Singers = string.IsNullOrWhiteSpace(currentKey)
            ? modalPage.AllSingers
            : modalPage.AllSingers!.Where(k => k.FullNameComplete
                .Contains(currentKey, StringComparison.OrdinalIgnoreCase)
                || k.Code.Contains(currentKey, StringComparison.OrdinalIgnoreCase)
                ).ToObservableCollection();
    }
}