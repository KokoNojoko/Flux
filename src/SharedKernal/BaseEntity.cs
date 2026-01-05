namespace SharedKernal
{
  public abstract class BaseEntity : IEntity
  {
    public Guid Id { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }

    protected BaseEntity()
    {
    }

    protected BaseEntity(Guid id, bool isActive, DateTime createdAt)
    {
      Id = id;
      IsActive = isActive;
      CreatedAt = createdAt;
    }
  }
}
