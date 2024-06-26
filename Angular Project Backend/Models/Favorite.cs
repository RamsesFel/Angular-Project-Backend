using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Angular_Project_Backend.Models;

public partial class Favorite
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? EventId { get; set; }

    public bool? IsFavorite { get; set; }

    [JsonIgnore]
    public virtual Event? Event { get; set; }

    [JsonIgnore]

    public virtual UserId? User { get; set; }
}
