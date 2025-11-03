namespace SongManager.Desktop.Controls;

public partial class SearchablePicker : ContentView
{
	public SearchablePicker()
	{
		InitializeComponent();
	}



    public static readonly BindableProperty ItemsSourceProperty =
                BindableProperty.Create(nameof(ItemsSource), typeof(ObservableCollection<SearchablePickerDto>), typeof(SearchablePicker));

    public static readonly BindableProperty SelectedItemProperty =
        BindableProperty.Create(nameof(SelectedItem), typeof(SearchablePickerDto), typeof(SearchablePicker), defaultBindingMode: BindingMode.TwoWay);
   
    public static readonly BindableProperty KeyProperty =
        BindableProperty.Create(nameof(Key), typeof(SearchablePickerDto), typeof(SearchablePicker), defaultBindingMode: BindingMode.TwoWay);

    public ObservableCollection<SearchablePickerDto> ItemsSource
    {
        get => (ObservableCollection<SearchablePickerDto>)GetValue(ItemsSourceProperty);
        set => SetValue(ItemsSourceProperty, value);
    }

    public SearchablePickerDto SelectedItem
    {
        get => (SearchablePickerDto)GetValue(SelectedItemProperty);
        set => SetValue(SelectedItemProperty, value);
    }
    public string Key
    {
        get => (string)GetValue(SelectedItemProperty);
        set => SetValue(SelectedItemProperty, value);
    }

    private ObservableCollection<SearchablePickerDto> _allItems = new();

    

    //private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
    //{
    //    var control = (SearchablePicker)bindable;
    //    control._allItems = ((ObservableCollection<SearchablePickerDto>)newValue)?.ToList() ?? new ObservableCollection<SearchablePickerDto>();
    //    control.OptionsList.ItemsSource = control._allItems;
    //}

    //private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    //{
    //    var keyword = e.NewTextValue?.ToLower() ?? "";
    //    OptionsList.ItemsSource = _allItems
    //        .Where(item => item.ToLower().Contains(keyword))
    //        .ToList();
    //}

    //private void OnOptionSelected(object sender, SelectionChangedEventArgs e)
    //{
    //    SelectedItem = e.CurrentSelection.FirstOrDefault();
    //}

}