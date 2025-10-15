using SongManager.Desktop.Enum;

namespace SongManager.Desktop.DTOs;

public record class GenderDto : BaseDto<Byte>
{
    public Gender Gender { get; set; } = Gender.None;
    public string Name => Gender.ToString();
}
