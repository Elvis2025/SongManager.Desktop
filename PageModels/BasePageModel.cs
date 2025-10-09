using CommunityToolkit.Mvvm.ComponentModel;
using SongManager.Desktop.Resx;
using System.Diagnostics;

namespace SongManager.Desktop.PageModels;

public abstract partial class BasePageModel : ObservableObject
{
    [ObservableProperty]
    private bool isBusy;

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
}
