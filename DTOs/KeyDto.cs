namespace SongManager.Desktop.DTOs;

public sealed record class KeyDto : BaseDto<byte>
{
    public string Name { get; set; } = string.Empty;
    public Key Key { get; set; } = Key.NA;

}
