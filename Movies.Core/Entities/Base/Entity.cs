namespace Movies.Core.Entities.Base;

public abstract class Entity : IEntity<int>
{
    public virtual int Id { get; init; }
}