using System;
using System.Collections.Generic;

namespace Lapostemobile_portail.Models;

public partial class CaracteristiquesArticle
{
    public int IdCaracteristiquesArticles { get; set; }

    public int IdArticle { get; set; }

    public int? TypeCaracteristiquesArticles { get; set; }

    public string? NomCaracteristiquesArticles { get; set; }

    public decimal? ValeurCarasteristiquesArticles { get; set; }

    public virtual Article IdArticleNavigation { get; set; } = null!;
}
