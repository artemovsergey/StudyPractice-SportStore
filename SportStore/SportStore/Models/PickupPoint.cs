using System;
using System.Collections.Generic;

namespace SportStore.Models;

public partial class PickupPoint
{
    public int Id { get; set; }

    public string NumberPoint { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string NumberStreet { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
