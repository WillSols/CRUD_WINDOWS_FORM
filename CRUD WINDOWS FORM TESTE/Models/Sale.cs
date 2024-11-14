using System;
using System.Collections.Generic;

namespace CRUD_WINDOWS_FORM_TESTE.Models;

public partial class Sale
{
    public int SaleId { get; set; }

    public string? GroupId { get; set; }
    public int? ClientId { get; set; }

    public int? ProductId { get; set; }

    public string? ProductName { get; set; }

    public string? ClientName { get; set; }

    public DateOnly? SaleDate { get; set; }

    public int? Qty { get; set; }

    public decimal UnitPrice { get; set; }

    //Nav para os objetos
    public virtual Clients? Client { get; set; }

    public virtual Products? Product { get; set; }
    //
    public bool Active { get; set; }
}
