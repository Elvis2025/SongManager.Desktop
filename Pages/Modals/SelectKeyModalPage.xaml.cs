using SongManager.Desktop.DTOs;
using SongManager.Desktop.PageModels.Modals;
using System.ComponentModel;
using System.Windows.Input;

namespace SongManager.Desktop.Pages.Modals;

public partial class SelectKeyModalPage : ContentPage
{
    private readonly SelectKeyModalPageModel pageModel;

    public SelectKeyModalPage(SelectKeyModalPageModel pageModel)
	{
		InitializeComponent();
        BindingContext = pageModel;
        this.pageModel = pageModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is SelectKeyModalPageModel vm)
        {
            //KeysCV.SelectedItems.Clear();

            foreach (var item in vm.CurrentKeysSelected ?? Enumerable.Empty<KeyDto>())
            {
                var match = vm.Keys?.FirstOrDefault(x => ReferenceEquals(x, item) || x.Id == item.Id);
                if (match != null) KeysCV.SelectedItems.Add(match);
            }

            var selectedIds = KeysCV.SelectedItems?.Cast<KeyDto>()
                             .Select(k => k.Id).ToHashSet() ?? null;

            if (selectedIds is null) return;
            foreach (var k in vm.Keys ?? Enumerable.Empty<KeyDto>())
                k.IsSelected = selectedIds!.Contains(k.Id);

            // ?? NUEVO: ordenar EN SITIO (sin reemplazar vm.Keys)
             vm.Keys = vm.Keys!
                .OrderByDescending(k => k.IsSelected) // seleccionados primero
                .ThenBy(k => k.Id)                    // secundario (cámbialo a k.Name si prefieres)
                .ToObservableCollection();


        }
    }
    private void FindKey(object sender, TextChangedEventArgs e)
    {
        var currentKey = e.NewTextValue ?? string.Empty;

        pageModel.Keys = string.IsNullOrWhiteSpace(currentKey)
            ? GlobalVariables.Keys.ToObservableCollection()
            : GlobalVariables.Keys.Where(k => k.Name
                .Contains(currentKey, StringComparison.OrdinalIgnoreCase))
                .ToObservableCollection();
    }
    
}