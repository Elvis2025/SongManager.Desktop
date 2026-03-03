namespace SongManager.Desktop.Controls;

public partial class ModernSearchBar : ContentView
{
    public ModernSearchBar()
    {
        InitializeComponent();
    }

    public static readonly BindableProperty LeftTextProperty =
        BindableProperty.Create(nameof(LeftText), typeof(string), typeof(ModernSearchBar), "Todos");

    public static readonly BindableProperty PlaceholderProperty =
        BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(ModernSearchBar), "Buscar...");

    public static readonly BindableProperty SearchTextProperty =
        BindableProperty.Create(nameof(SearchText), typeof(string), typeof(ModernSearchBar), string.Empty, BindingMode.TwoWay);

    public string LeftText
    {
        get => (string)GetValue(LeftTextProperty);
        set => SetValue(LeftTextProperty, value);
    }

    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }

    public string SearchText
    {
        get => (string)GetValue(SearchTextProperty);
        set => SetValue(SearchTextProperty, value);
    }

    public event EventHandler<TextChangedEventArgs>? SearchTextChanged;
    public event EventHandler? SearchRequested;

    private void SearchEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        SearchTextChanged?.Invoke(this, e);
    }

    private void SearchTapped(object sender, TappedEventArgs e)
    {
        SearchRequested?.Invoke(this, EventArgs.Empty);
    }
}
