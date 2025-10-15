namespace SongManager.Desktop.DTOs;
[AutoMap(typeof(Users))]
public record class UsersDto : BaseDto<int>
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string SecondName { get; set; } = string.Empty;
    public string FirstSurname { get; set; } = string.Empty;
    public string SecondSurname { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string FullName => $"{FirstName} {FirstSurname}";
    public bool IsAdmin { get; set; }
    public Users User => this.Map<Users>();
}
