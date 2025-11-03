namespace SongManager.Desktop.DTOs;

public sealed record class KeyDto : BaseDto<byte>
{
    public string Name => Key.GetKeyName();
    public Key Key { get; set; } = Key.NA;
    public bool IsSelected { get; set; }

}
