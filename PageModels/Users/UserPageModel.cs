namespace SongManager.Desktop.PageModels;
[RegisterPageModel]
public partial class UserPageModel : BasePageModel
{
    private readonly IRepository<Users> userRepository;

    [ObservableProperty]
    private ObservableCollection<UsersDto>? users;

    [ObservableProperty]
    private UsersDto? currentUser = new();

    [ObservableProperty]
    private bool canManageUsers;

    [ObservableProperty]
    private bool isEditingUser;

    [ObservableProperty]
    private string editorTitle = "Crear usuario";

    public UserPageModel(IRepository<Users> userRepository)
    {
        this.userRepository = userRepository;
        Init();
    }

    public void Init()
    {
        Task.Run(async () =>
        {
            var data = (await userRepository.GetAllAsync()).ToList();
            Users = new(data.Map<UsersDto>());
            await ResolvePermissionsAsync(data);
            PrepareNewUser();
        });
    }

    private async Task ResolvePermissionsAsync(List<Users> data)
    {
        if (!data.Any())
        {
            CanManageUsers = true;
            return;
        }

        var current = data.FirstOrDefault(x => x.Id == Constants.GlobalVariables.GetUserId);
        if (current is null)
        {
            // fallback: si no hay sesión definida, usar el primer admin
            current = data.FirstOrDefault(x => x.IsAdmin);
            if (current is not null)
                Preferences.Set(Constants.GlobalVariables.UserId, current.Id);
        }

        CanManageUsers = current?.IsAdmin == true;
        await Task.CompletedTask;
    }

    [RelayCommand]
    public async Task SaveUser()
    {
        if (!CanManageUsers)
        {
            await WarningAlert("Permisos", "Solo el administrador puede crear o editar usuarios.");
            return;
        }

        if (CurrentUser is null) return;
        if (string.IsNullOrWhiteSpace(CurrentUser.Username) ||
            string.IsNullOrWhiteSpace(CurrentUser.Email) ||
            string.IsNullOrWhiteSpace(CurrentUser.FirstName) ||
            string.IsNullOrWhiteSpace(CurrentUser.FirstSurname) ||
            string.IsNullOrWhiteSpace(CurrentUser.Password))
        {
            await WarningAlert("Validación", "Completa usuario, correo, nombre, apellido y contraseña.");
            return;
        }

        IsBusy = true;
        try
        {
            var totalUsers = Users?.Count ?? 0;
            if (!IsEditingUser)
            {
                CurrentUser.CreationTime = DateTime.Now;
                if (totalUsers == 0)
                {
                    CurrentUser.IsAdmin = true;
                }
                await userRepository.InsertAsync(CurrentUser.User);
            }
            else
            {
                await userRepository.UpdateAsync(CurrentUser.User);
            }

            Init();
            await SuccessAlert("Éxito", "Usuario guardado correctamente.");
        }
        catch (Exception ex)
        {
            await ErrorAlert("Error", ex.Message);
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    public void PrepareNewUser()
    {
        CurrentUser = new UsersDto
        {
            IsAdmin = false
        };
        IsEditingUser = false;
        EditorTitle = "Crear usuario";
    }

    [RelayCommand]
    public void EditUser(UsersDto user)
    {
        if (!CanManageUsers || user is null) return;
        CurrentUser = new UsersDto
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            FirstName = user.FirstName,
            SecondName = user.SecondName,
            FirstSurname = user.FirstSurname,
            SecondSurname = user.SecondSurname,
            Password = user.Password,
            IsAdmin = user.IsAdmin,
            CreationTime = user.CreationTime,
            CreatorUserId = user.CreatorUserId,
            IsActive = user.IsActive,
            IsDeleted = user.IsDeleted
        };
        IsEditingUser = true;
        EditorTitle = "Editar usuario";
    }
}
