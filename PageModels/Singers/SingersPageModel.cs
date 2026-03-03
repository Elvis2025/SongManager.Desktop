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
    [ObservableProperty]
    private bool canManageSingers;

    private readonly IRepository<Singers> singersRepository;
    private readonly IRepository<Users> usersRepository;

    public SingersPageModel(IRepository<Singers> singersRepository, IRepository<Users> usersRepository)
    {
        this.singersRepository = singersRepository;
        this.usersRepository = usersRepository;
        Init();
    }

    public void Init()
    {
        Task.Run(async () =>
        {
            var singers = await singersRepository.GetAllAsync();
            SingersDto = new(singers.Map<SingersDto>());
            foreach (var (singer, i) in SingersDto.Select((value, i) => (value, i)))
            {
                singer.HexColor = (i % 2) == 0 ? Color.FromArgb("#FFFFFF") : Color.FromArgb("#E1E1E1");
            }
            await ResolvePermissionsAsync();
        });
    }

    private async Task ResolvePermissionsAsync()
    {
        var users = (await usersRepository.GetAllAsync()).ToList();
        if (!users.Any())
        {
            CanManageSingers = true;
            return;
        }

        var currentUser = users.FirstOrDefault(x => x.Id == GlobalVariables.GetUserId);
        CanManageSingers = currentUser?.IsAdmin == true;
    }

    [RelayCommand]
    public async Task CreateSinger()
    {
        if (!CanManageSingers)
        {
            await WarningAlert("Permisos", "Solo el administrador puede crear cantantes.");
            return;
        }

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
        if (!CanManageSingers)
        {
            await WarningAlert("Permisos", "Solo el administrador puede editar cantantes.");
            return;
        }

        IsBusy = true;
        try
        {
            if (singerDto is null || singerDto.Id < 0) return;
            Preferences.Set(GlobalVariables.SingerId, singerDto.Id);
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
        if (!CanManageSingers)
        {
            await WarningAlert("Permisos", "Solo el administrador puede eliminar cantantes.");
            return;
        }

        IsBusy = true;
        try
        {
            if (singerDto is null || singerDto.Id < 0) return;
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
