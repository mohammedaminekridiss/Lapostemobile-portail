using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lapostemobile_portail.Models;

public partial class Prospect
{
    public int IdProspect { get; set; }

    public int IdCivilite { get; set; }

    public int IdSouscription { get; set; }

    public int? IdAdresseFacturation { get; set; }

    public int? IdAdresseLivraison { get; set; }

    public int IdModepaiementSouscription { get; set; }

    public string Nom { get; set; } = null!;

    public string Prenom { get; set; } = null!;

    public DateTime DateNaissance { get; set; }

    public string? DepNaissance { get; set; }

    public DateTime? DatCre { get; set; }

    public DateTime? DatMod { get; set; }

    public int? IdCoordonneesBancaires { get; set; }

    [Required(ErrorMessage = "L'adresse e-mail est requise.")]
    [EmailAddress(ErrorMessage = "L'adresse e-mail n'est pas valide.")]
    public string? Email { get; set; } = string.Empty;

    public string? NumeroFixe { get; set; }

    public string? NumeroMobile { get; set; }

    public virtual CoordonneesBancaire? IdCoordonneesBancairesNavigation { get; set; }
}
