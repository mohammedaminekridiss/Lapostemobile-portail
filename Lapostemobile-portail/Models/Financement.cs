namespace Lapostemobile_portail.Models;

public partial class Financement
{
    public int IdFinancement { get; set; }

    public decimal MontantFinancement { get; set; }

    public decimal DureeFinancement { get; set; }

    public int IdOption { get; set; }

    public virtual Option IdOptionNavigation { get; set; } = null!;

    public virtual ICollection<Ligne> Lignes { get; set; } = new List<Ligne>();
}
