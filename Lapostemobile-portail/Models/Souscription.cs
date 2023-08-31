using System;
using System.Collections.Generic;

namespace Lapostemobile_portail.Models;

public partial class Souscription
{
    public int IdSouscription { get; set; }

    public int IdStatutSouscription { get; set; }

    public DateTime DateSouscription { get; set; }

    public string? NumContrat { get; set; }

    public DateTime? DateModification { get; set; }

    public decimal IdModeLivraison { get; set; }

    public decimal? PrixLivraison { get; set; }

    public decimal? MontantPaye { get; set; }

    public virtual StatutSouscription IdStatutSouscriptionNavigation { get; set; } = null!;

    public virtual ICollection<Ligne> Lignes { get; set; } = new List<Ligne>();
}
