using SongManager.Desktop.Constants;
using SongManager.Desktop.Pages.Singers;

namespace SongManager.Desktop.PageModels;
[RegisterPageModel]
public partial class SingersPageModel : BasePageModel
{
    [ObservableProperty]
    private SingersDto? currentSingerDto;
    [ObservableProperty]
    private ObservableCollection<SingersDto>? singersDto;



    private readonly IRepository<Singers> singersRepository;

    public SingersPageModel(IRepository<Singers> singersRepository)
    {
        this.singersRepository = singersRepository;
        Init();
    }

    public void Init()
    {
        Task.Run(async () =>
        {
            var singers = await singersRepository.GetAllAsync();
            SingersDto = new(singers.Map<SingersDto>());
        });
    }
    [RelayCommand]
    public async Task CreateSinger()
    {
        IsBusy = true;
        try
        {
            await PushModalAsync<CreateSingersPage>();
        }
        catch (Exception ex)
        {
            await ErrorAlert("Error", $"Failed to creating singers: {ex.Message}");
        }
        finally
        {
            IsBusy = false;
        }
    }


    [RelayCommand]
    public async Task EditSinger()
    {
        IsBusy = true;
        try
        { if (CurrentSingerDto is null || CurrentSingerDto!.Id < 0) return;
            Preferences.Set(GlobalVariables.SingerId, CurrentSingerDto!.Id);
            await PushModalAsync<CreateSingersPage>();
        }
        catch (Exception ex)
        {
            await ErrorAlert("Error", $"Failed to creating singers: {ex.Message}");
        }
        finally
        {
            IsBusy = false;
            CurrentSingerDto = new();
        }
    }

    
  
}
