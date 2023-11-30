using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestAPI.Models;

[Keyless]
public partial class MSupplierItem
{
    public int? IdSupplier { get; set; }

   // [Display(Name = "id")]
    public int? IdItem { get; set; }

    public decimal? Price { get; set; }

    public virtual MItem? IdItemNavigation { get; set; }

    public virtual MSupplier? IdSupplierNavigation { get; set; }
}
