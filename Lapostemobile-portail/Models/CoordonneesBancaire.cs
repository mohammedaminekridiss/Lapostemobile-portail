using System;
using System.Collections.Generic;

namespace Lapostemobile_portail.Models;

public partial class CoordonneesBancaire
{
    public int IdCoordonnees { get; set; }

    public string? TitulaireCompte { get; set; }

    public string? NomBanque { get; set; }

    public string? Iban { get; set; }

    public string? CodeBic { get; set; }

    public DateTime? DateCreation { get; set; }

    public DateTime? DateModification { get; set; }

    public virtual ICollection<Prospect> Prospects { get; set; } = new List<Prospect>();
}
