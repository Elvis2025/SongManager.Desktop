using SongManager.Desktop.Attributes;

namespace SongManager.Desktop.Pages;
[RegisterAsRoute]
public partial class UserPage : BaseContentPage<UserPageModel>
{
    public UserPage(UserPageModel basePageModel) : base(basePageModel)
    {
        InitializeComponent();
    }
}