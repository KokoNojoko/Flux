namespace Flux.Domain
{
  public abstract class BaseEntity : IEntity
  {
    public Guid Id { get; set; }
    public bool IsActive { get; set; }
  }
}
