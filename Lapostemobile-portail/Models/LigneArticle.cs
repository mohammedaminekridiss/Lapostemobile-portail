using System;
using System.Collections.Generic;

namespace Lapostemobile_portail.Models;

public partial class LigneArticle
{
    public int IdLigneArticle { get; set; }

    public int IdLigne { get; set; }

    public int? IdArticle { get; set; }

    public decimal? PrixPaye { get; set; }

    public decimal? TotalSubvention { get; set; }

    public DateTime? DatCre { get; set; }

    public DateTime? DatMod { get; set; }

    public string? Imei { get; set; }

    public virtual Ligne IdLigneNavigation { get; set; } = null!;
}
