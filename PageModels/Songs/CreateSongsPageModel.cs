
namespace SongManager.Desktop.PageModels;
[RegisterPageModel]
public partial class CreateSongsPageModel : BasePageModel
{
    private readonly IRepository<Singers> singerRepository;
    [ObservableProperty]
    private ObservableCollection<SingersDto>? singers;
    public CreateSongsPageModel(IRepository<Singers> singerRepository)
    {
        this.singerRepository = singerRepository;
    }

    private async Task LoadSingersAsync()
    {
        try
        {
            var singers = await singerRepository.GetAllAsync();
            Singers = new(singers.Map<SingersDto>());
        }
        catch (Exception ex)
        {
            await ErrorAlert("Error", $"Failed to load singers: {ex.Message}");
        }
    }

}
