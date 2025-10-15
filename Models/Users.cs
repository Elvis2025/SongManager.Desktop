using SongManager.Desktop.Attributes;
using SongManager.Desktop.DTOs;
using SongManager.Desktop.Extensions;
using SQLite;

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
    [Ignore]
    public UsersDto UserDto => this.Map<UsersDto>();
}
