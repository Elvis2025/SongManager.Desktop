namespace SongManager.Desktop.Pages.Users;
[RegisterAsRoute]
public partial class UserPage : BaseContentPage<UserPageModel>
{
    public UserPage(UserPageModel basePageModel) : base(basePageModel)
    {
        InitializeComponent();
    }
}