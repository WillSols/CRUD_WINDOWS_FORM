using System;
using System.Collections.Generic;

namespace CRUD_WINDOWS_FORM_TESTE.Models;

public partial class Products
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public string? SKU { get; set; }

    public int Stock { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public bool Active { get; set; }
}
