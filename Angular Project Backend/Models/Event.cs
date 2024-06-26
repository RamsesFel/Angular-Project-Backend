using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Angular_Project_Backend.Models;

public partial class Event
{
    public int Id { get; set; }

    public string? Description { get; set; }
}
