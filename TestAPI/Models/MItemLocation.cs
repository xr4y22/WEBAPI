using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class MItemLocation
{
    public int? IdItem { get; set; }

    public int? IdLocation { get; set; }

    public int? Stock { get; set; }

    public virtual MItem? IdItemNavigation { get; set; }

    public virtual MLocation? IdLocationNavigation { get; set; }
}
