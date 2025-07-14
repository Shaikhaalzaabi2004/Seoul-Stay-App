using System;
using System.Collections.Generic;

namespace SeoulStay.Models;

public partial class Amenity
{
    public long Id { get; set; }

    public Guid Guid { get; set; }

    public string Name { get; set; } = null!;

    public string? IconName { get; set; }

    public virtual ICollection<ItemAmenity> ItemAmenities { get; set; } = new List<ItemAmenity>();
}
