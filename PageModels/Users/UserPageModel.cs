namespace SongManager.Desktop.PageModels;
[RegisterPageModel]
public partial class UserPageModel : BasePageModel
{
    private readonly IRepository<Users> userRepository;
    [ObservableProperty]
    public List<UsersDto>? users;
    [ObservableProperty]
    public UsersDto? currentUser;
    public UserPageModel(IRepository<Users> userRepository)
    {
        this.userRepository = userRepository;
    }


}
