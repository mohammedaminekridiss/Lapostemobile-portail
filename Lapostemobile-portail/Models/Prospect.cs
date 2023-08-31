﻿using System;
using System.Collections.Generic;

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

    public string? Email { get; set; }

    public string? NumeroFixe { get; set; }

    public string? NumeroMobile { get; set; }

    public virtual CoordonneesBancaire? IdCoordonneesBancairesNavigation { get; set; }
}