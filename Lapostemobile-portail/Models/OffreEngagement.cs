using System;
using System.Collections.Generic;

namespace Lapostemobile_portail.Models;

public partial class OffreEngagement
{
    public int IdOffreEngagement { get; set; }

    public int DureeEngagement { get; set; }

    public decimal Prix { get; set; }

    public string? LibelleMarketing { get; set; }

    public decimal MontantSubvention { get; set; }

    public string? Caracteristiques { get; set; }

    public bool? Est5g { get; set; }

    public virtual ICollection<Ligne> Lignes { get; set; } = new List<Ligne>();

    public virtual ICollection<PrixArticle> PrixArticles { get; set; } = new List<PrixArticle>();
}
