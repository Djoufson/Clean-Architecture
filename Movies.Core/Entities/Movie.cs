using Movies.Core.Entities.Base;

namespace Movies.Core.Entities;

public class Movie : Entity
{
    public string Name { get; set; } = default!;
    public string Director { get; set; } = default!;
    public int ReleasedYear { get; set; }
}
