namespace FindChurch.Core.Entities;

public abstract class BaseEntity
{
    protected BaseEntity()
    {
        CreatedAt = DateTime.UtcNow;
        IsDeleted = false;
    }

    public Guid Id { get; set; }
    public DateTime CreatedAt { get; private set; }
    public bool IsDeleted { get; private set; }
    
    public virtual void SetAsDeleted() => IsDeleted = true;
}