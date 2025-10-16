using CommunityToolkit.Maui.Core.Extensions;
using SongManager.Desktop.Constants;
using SongManager.Desktop.Enum;
using SongManager.Desktop.Pages.Singers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SongManager.Desktop.PageModels;
[RegisterPageModel]
public partial class CreateSingersPageModel : BasePageModel
{
    private readonly IRepository<Singers> singersRepository;
    [ObservableProperty]
    private bool isCreateMoreOneSinger;
    [ObservableProperty]
    private bool isGenderSelected = false;
    [ObservableProperty]
    private bool isCreatingSinger;
    [ObservableProperty]
    private SingersDto? editSingerDto;

    [ObservableProperty]
    private string? createOrUpDate;


    public CreateSingersPageModel(IRepository<Singers> singersRepository)
    {
        this.singersRepository = singersRepository;
        Init();
    }

    public void Init()
    {
        Task.Run(async () =>
        {
            try
            {

                var singerId = Preferences.Get(GlobalVariables.SingerId, -1);

                var singer = await singersRepository.GetAsync(singerId);
                if (singer is null)
                {
                    IsCreatingSinger = true;
                    CreateOrUpDate = "Crear nuevo cantante";
                    return;
                }
                EditSingerDto = singer.Map<SingersDto>();
                CurrentSingerDto = EditSingerDto;
                CurrentGender = GlobalVariables.Genres.FirstOrDefault(x => x.Gender == CurrentSingerDto.GenderId);
                CurrentVocalRangesDto = GlobalVariables.VocalRanges.FirstOrDefault(x => x.VocalRange == CurrentSingerDto.VocalRangeId);
                IsGenderSelected = true;
                IsCreatingSinger = false;
                CreateOrUpDate = "Editar cantante";
            }
            catch (Exception e)
            {
                await ErrorAlert("Error Song Manager", e.Message);
            }
        });
    }
    [RelayCommand]
    public async Task CreateSinger()
    {
        IsBusy = true;
        try
        {
            Preferences.Get(GlobalVariables.SingerId, -1);

            if (!await SingerDataIsValid()) return;
            CurrentSingerDto!.CreationTime = DateTime.Now;
            CurrentSingerDto!.GenderId = CurrentGender!.Gender;
            CurrentSingerDto!.VocalRangeId = CurrentVocalRangesDto!.VocalRange;

            if (IsCreatingSinger)
            {
                await singersRepository.InsertAsync(CurrentSingerDto!.Singer);
                await SuccessAlert("Éxito", $"Cantante creado exitosamente!!!");
            }
            else
            {
                await singersRepository.UpdateAsync(CurrentSingerDto!.Singer);
                await SuccessAlert("Éxito", $"Cambios guardados exitosamente!!!");
            }
            if (IsCreateMoreOneSinger) return;
            await GoBack();
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

    public void GenderSelected()
    {
        if (CurrentGender is null || CurrentGender.Gender == Gender.None) return;
        VocalRangesDto = GlobalVariables.VocalRanges
                         .Where(x => x.Gender == CurrentGender!.Gender)
                         .ToObservableCollection();
        CurrentVocalRangesDto = new();
        IsGenderSelected = true;
    }
    public async Task<bool> SingerDataIsValid()
    {
        if (CurrentSingerDto is null || CurrentSingerDto.Singer is null)
        {
            await ErrorAlert("Error", $"Error validando los datos del cantante");
            return false;
        }

        if (string.IsNullOrEmpty(CurrentSingerDto.FirstName) ||
            string.IsNullOrEmpty(CurrentSingerDto.FirstSurname)
            )
        {
            await ErrorAlert("Error", $"Es obligatorio digitar el primer nombre y el  primer apellido del cantante");
            return false;
        }
        return true;
    }
}
