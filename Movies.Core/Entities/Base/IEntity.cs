namespace Movies.Core.Entities.Base
{
    public interface IEntity<TId>
    {
        TId Id { get; init; }
    }
}