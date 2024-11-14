using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CRUD_WINDOWS_FORM_TESTE.Models;

public partial class Clients
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    [MaxLength(3)]
    public string? DDD { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public bool Active { get; set; }
}
