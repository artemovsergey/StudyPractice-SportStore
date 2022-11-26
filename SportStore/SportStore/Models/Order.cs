using System;
using System.Collections.Generic;

namespace SportStore.Models;

public partial class Order
{
    public int Id { get; set; }

    public string OrderList { get; set; } = null!;

    public DateTime OrderDate { get; set; }

    public DateTime DeliveryDate { get; set; }

    public int PickupPointId { get; set; }

    public string Client { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string Status { get; set; } = null!;

    public virtual ICollection<OrderProduct> OrderProducts { get; } = new List<OrderProduct>();

    public virtual PickupPoint PickupPoint { get; set; } = null!;
}
