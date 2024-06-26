using System;
using System.Collections.Generic;

namespace Angular_Project_Backend.Models;

public partial class UserId
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
}
