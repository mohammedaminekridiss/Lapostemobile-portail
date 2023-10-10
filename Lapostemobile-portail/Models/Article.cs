namespace Lapostemobile_portail.Models;

public partial class Article
{
    public int IdArticle { get; set; }

    public int IdTypeArticle { get; set; }

    public string? CodeSap { get; set; }

    public string LibelleArticle { get; set; } = null!;

    public int? Ordre { get; set; }

    public bool Statut { get; set; }

    public string? FichierImageVignette { get; set; }

    public string? FichierImage { get; set; }

    public string? LibelleCourt { get; set; }

    public int? IdFabriquant { get; set; }

    public DateTime? DateFinCcial { get; set; }

    public virtual ICollection<CaracteristiquesArticle> CaracteristiquesArticles { get; set; } = new List<CaracteristiquesArticle>();

    public virtual ICollection<PrixArticle> PrixArticles { get; set; } = new List<PrixArticle>();
}
