using SongManager.Desktop.Enum;

namespace SongManager.Desktop.DTOs;

public record class VocalRangeDto : BaseDto<byte>
{
    public string Name => (VocalRange.ToString().Contains('_') ? VocalRange.ToString().Replace('_',' ') : VocalRange.ToString());
    public Gender Gender { get; set; } = Gender.None;
    public VocalRange VocalRange { get; set; } = VocalRange.None;
    
}
