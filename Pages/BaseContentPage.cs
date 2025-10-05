using System.Diagnostics;

namespace SongManager.Desktop.Pages;

public abstract partial class BaseContentPage<TViewModel>(TViewModel viewModel, bool shouldUseSafeArea = true)
                            : BaseContentPage(viewModel, shouldUseSafeArea) where TViewModel
                            : BasePageModel
{
    public new TViewModel BindingContext => (TViewModel)base.BindingContext;
}

public abstract partial class BaseContentPage : ContentPage
{
    protected BaseContentPage(object? viewModel = null, bool shouldUseSafeArea = true)
    {
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Debug.WriteLine($"OnAppearing: {Title}");
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        Debug.WriteLine($"OnDisappearing: {Title}");
    }
}
