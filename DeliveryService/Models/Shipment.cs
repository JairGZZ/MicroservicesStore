using System;
using System.Collections.Generic;

namespace DeliveryService.Models;

public partial class Shipment
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public string Address { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime? ShippedDate { get; set; }
}
