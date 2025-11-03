namespace SongManager.Desktop.DTOs;

public abstract record class BaseDto<TPrimaryKey> : IBaseEntity
{
    public virtual TPrimaryKey Id { get; set; } = default!;
    public DateTime CreationTime { get; set; }
    public DateTime? LastModified { get; set; }
    public DateTime? DeletionTime { get; set; }
    public int? CreatorUserId { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
}
