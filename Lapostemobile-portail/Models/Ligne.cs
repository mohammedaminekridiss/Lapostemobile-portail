using System;
using System.Collections.Generic;

namespace Lapostemobile_portail.Models;

public partial class Ligne
{
    public int IdLigne { get; set; }

    public int IdSouscription { get; set; }

    public int? IdOffreEngagement { get; set; }

    public decimal PrixVenteOffre { get; set; }

    public DateTime? DatCre { get; set; }

    public DateTime? DatMod { get; set; }

    public int? IdFinancement { get; set; }

    public virtual Financement? IdFinancementNavigation { get; set; }

    public virtual OffreEngagement? IdOffreEngagementNavigation { get; set; }

    public virtual Souscription IdSouscriptionNavigation { get; set; } = null!;

    public virtual ICollection<LigneArticle> LigneArticles { get; set; } = new List<LigneArticle>();

    public virtual ICollection<LigneOption> LigneOptions { get; set; } = new List<LigneOption>();
}
