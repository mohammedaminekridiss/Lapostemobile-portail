using System;
using System.Collections.Generic;

namespace Lapostemobile_portail.Models;

public partial class Option
{
    public int IdOption { get; set; }

    public int IdGroupeOption { get; set; }

    public string LibelleOption { get; set; } = null!;

    public string? LibelleMarketing { get; set; }

    public decimal? OrdreAffichage { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Financement> Financements { get; set; } = new List<Financement>();

    public virtual ICollection<LigneOption> LigneOptions { get; set; } = new List<LigneOption>();
}
