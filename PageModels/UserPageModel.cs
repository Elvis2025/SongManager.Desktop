using CommunityToolkit.Mvvm.ComponentModel;
using SongManager.Desktop.Attributes;
using SongManager.Desktop.DTOs;
using SongManager.Desktop.Models;
using SongManager.Desktop.Repositories.SQLite;

namespace SongManager.Desktop.PageModels;
[RegisterPageModel]
public partial class UserPageModel : BasePageModel
{
    private readonly IRepository<User> userRepository;
    [ObservableProperty]
    public List<UserDto> users;
    [ObservableProperty]
    public UserDto currentUser;
    public UserPageModel(IRepository<User> userRepository)
    {
        this.userRepository = userRepository;
    }


}
