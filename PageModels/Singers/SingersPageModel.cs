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
            foreach(var (singer, i) in SingersDto.Select((value, i) => (value, i)))
            {
                if((i % 2) == 0)
                {
                    singer.HexColor = Color.FromArgb("#FFFFFF");
                    continue;
                }
                singer.HexColor = Color.FromArgb("#E1E1E1");

            }
        });
    }

    [RelayCommand]
    public async Task CreateSinger()
    {
        IsBusy = true;
        try
        {
            Preferences.Set(GlobalVariables.SingerId, -1);
            await PushRelativePageAsync<CreateSingersPage>();
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
    public async Task EditSinger(SingersDto singerDto)
    {
        IsBusy = true;
        try
        {   
            if (singerDto is null || singerDto!.Id < 0) return;
            Preferences.Set(GlobalVariables.SingerId, singerDto!.Id);
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
    
    [RelayCommand]
    public async Task DeleteSinger(SingersDto singerDto)
    {
        IsBusy = true;
        try
        {   
            if (singerDto is null || singerDto!.Id < 0) return;
            await singersRepository.DeleteAsync(singerDto.Singer);
            Init();
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
