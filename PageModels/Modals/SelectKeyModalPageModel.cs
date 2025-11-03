using System.Windows.Input;

namespace SongManager.Desktop.PageModels.Modals;

public partial class SelectKeyModalPageModel : BasePageModel
{
    [ObservableProperty]
    private ObservableCollection<KeyDto>? keys = GlobalVariables.Keys.ToObservableCollection();

    [ObservableProperty]
    private ObservableCollection<KeyDto>? currentKeysSelected;
    
    public Action<ObservableCollection<KeyDto>>? OnSelectedKey;

    [RelayCommand]
    public void SelectKey(IList<object> selectedItems)
    {

        var selected = selectedItems.Cast<KeyDto>().ToList();

        if (selected is null) return;

        CurrentKeysSelected = new(selected);

    }

    [RelayCommand]
    public void Next()
    {
        if (CurrentKeysSelected is null || !CurrentKeysSelected.Any()) return;
 
        OnSelectedKey?.Invoke(CurrentKeysSelected!);
    }


}
