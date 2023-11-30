using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class MItem
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public decimal? SellingPrice { get; set; }
}
