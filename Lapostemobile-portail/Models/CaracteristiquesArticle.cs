using System;
using System.Collections.Generic;

namespace Lapostemobile_portail.Models;

public partial class CaracteristiquesArticle
{
    public int IdCaracteristiquesArticles { get; set; }

    public int IdArticle { get; set; }

    public string? NomCaracteristiquesArticles { get; set; }

    public string? ValeurCarasteristiquesArticles { get; set; }

    public virtual Article IdArticleNavigation { get; set; } = null!;
}
