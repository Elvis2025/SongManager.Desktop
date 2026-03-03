namespace SongManager.Desktop.Models;
[SQLiteEntity]
public class Users : BaseEntity<int>
{
    [Unique]
    public string Username { get; set; } = string.Empty;
    [Unique]
    public string Email { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string SecondName { get; set; } = string.Empty;
    public string FirstSurname { get; set; } = string.Empty;
    public string SecondSurname { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public bool IsAdmin { get; set; }
    [Ignore]
    public UsersDto UserDto => this.Map<UsersDto>();
}
