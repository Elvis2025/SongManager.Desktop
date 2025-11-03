namespace SongManager.Desktop.PageModels.Modals;

public partial class SelectSingersModalPageModel : BasePageModel
{
    [ObservableProperty]
    private ObservableCollection<SingersDto>? singers;
    [ObservableProperty]
    private SingersDto? currentSingersSelected;

    [ObservableProperty]
    private ObservableCollection<SingersDto>? allSingers;

    public Action<SingersDto>? OnSelectedSinger;


    [RelayCommand]
    public void SelectSinger()
    {
        if (CurrentSingersSelected is null) return;
        OnSelectedSinger?.Invoke(CurrentSingersSelected);
    }

   
}
