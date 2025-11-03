using SongManager.Desktop.Constants;
using SongManager.Desktop.Enum;

namespace SongManager.Desktop.PageModels;

public abstract partial class BasePageModel : ObservableObject
{
    [ObservableProperty]
    private bool isBusy;
    [ObservableProperty]
    private SingersDto? currentSingerDto = new();
    [ObservableProperty]
    private ObservableCollection<VocalRangeDto>? vocalRangesDto = new(GlobalVariables.VocalRanges);
    [ObservableProperty]
    private ObservableCollection<GenderDto>? genres = new(GlobalVariables.Genres);
    [ObservableProperty]
    private VocalRangeDto? currentVocalRangesDto = new();
    [ObservableProperty]
    private GenderDto? currentGender = new();
    [ObservableProperty]
    private bool isGenderSelected = false;

    public Action? GoModalBack;
    public void GenderSelected()
    {
        if (CurrentGender is null || CurrentGender.Gender == Gender.None) return;
        VocalRangesDto = GlobalVariables.VocalRanges
                         .Where(x => x.Gender == CurrentGender!.Gender)
                         .ToObservableCollection();
        CurrentVocalRangesDto = new();
        IsGenderSelected = true;
    }
    public static async Task SuccessAlert(string title, string message)
    {
        await Shell.Current.DisplayAlert(title, message, SongManagerResources.Ok);
    }

    public static async Task ErrorAlert(string title, string message)
    {
        await Shell.Current.DisplayAlert(title, message, SongManagerResources.Ok);
    }
    public static async Task WarningAlert(string title, string message)
    {
        await Shell.Current.DisplayAlert(title, message, SongManagerResources.Ok);
    }

    public static async Task PushRelativePageAsync<T>() where T : ContentPage
    {
        try
        {
            await Shell.Current.GoToAsync($"{typeof(T).Name}");
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            await Shell.Current.DisplayAlert("Song Manager Error", e.Message, SongManagerResources.Ok);
        }
    }

    public static async Task PushAsync<T>() where T : ContentPage
    {
        try
        {
            await Shell.Current.Navigation.PushAsync(SongManagerApp.CreateInstance<T>());
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            await Shell.Current.DisplayAlert("Song Manager Error", e.Message, SongManagerResources.Ok);
        }
    }
    public static async Task PushModalAsync<T>() where T : ContentPage
    {
        try
        {
            await Shell.Current.Navigation.PushModalAsync(SongManagerApp.CreateInstance<T>());
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            await Shell.Current.DisplayAlert("Song Manager Error", e.Message, SongManagerResources.Ok);
        }
    }
    public static async Task PopModalAsync()
    {
        try
        {
            await Shell.Current.Navigation.PopModalAsync();
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            await Shell.Current.DisplayAlert("Song Manager Error", e.Message, SongManagerResources.Ok);
        }
    }

    [RelayCommand]
    public static async Task PopModal()
    {
        try
        {
            await PopModalAsync();
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            await Shell.Current.DisplayAlert("Song Manager Error", e.Message, SongManagerResources.Ok);
        }
    }

    [RelayCommand]
    public async Task GoModalBackAction()
    {
        try
        {
            GoModalBack?.Invoke();
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            await Shell.Current.DisplayAlert("Song Manager Error", e.Message, SongManagerResources.Ok);
        }
    }

    [RelayCommand]
    public async Task GoBack()
    {
        try
        {
            await Shell.Current.GoToAsync("..");
        }
        catch (Exception e)
        {
            Debug.Write(e.Message);
            await ErrorAlert("Song manager navigation Error", e.Message);
        }
        finally
        {
            IsBusy = false;
        }

    }

    public static async Task PushAsync<T>(T Page) where T : ContentPage
    {
        try
        {
            await Shell.Current.Navigation.PushAsync(Activator.CreateInstance<T>());
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            await Shell.Current.DisplayAlert("Song Manager Error", e.Message, SongManagerResources.Ok);
        }
    }


    public static async Task PushRelativePageAsync<T>(Dictionary<string, object> param) where T : ContentPage
    {
        try
        {
            await Shell.Current.GoToAsync($"{typeof(T).Name}", param);
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            await Shell.Current.DisplayAlert("Song Manager Error", e.Message, SongManagerResources.Ok);
        }
    }

    public static async Task PushPageAsync<T>() where T : ContentPage
    {
        try
        {
            await Shell.Current.GoToAsync($"//{typeof(T).Name}");
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            await Shell.Current.DisplayAlert("Spend Flow Error", e.Message, SongManagerResources.Ok);
        }
    }

    private static INavigation Nav =>
   Application.Current?.Windows.FirstOrDefault()?.Page?.Navigation
   ?? throw new InvalidOperationException(
       "No hay NavigationPage en la raíz. Envuelve tu MainPage en un NavigationPage.");

    public static Task PushAsync(Page page) =>
      page is null
          ? Task.FromException(new ArgumentNullException(nameof(page)))
          : MainThread.InvokeOnMainThreadAsync(() => Nav.PushAsync(page));

    public static Task PushModalAsync(Page page) =>
      page is null
          ? Task.FromException(new ArgumentNullException(nameof(page)))
          : MainThread.InvokeOnMainThreadAsync(() => Nav.PushModalAsync(page));


}
