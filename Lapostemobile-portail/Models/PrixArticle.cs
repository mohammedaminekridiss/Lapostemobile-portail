namespace Lapostemobile_portail.Models;

public partial class PrixArticle
{
    public int IdPrixArticle { get; set; }

    public int IdArticle { get; set; }

    public int IdOffreEngagement { get; set; }

    public decimal? PrixArticle1 { get; set; }

    public DateTime? DateInsert { get; set; }

    public virtual Article IdArticleNavigation { get; set; } = null!;

    public virtual OffreEngagement IdOffreEngagementNavigation { get; set; } = null!;
}
