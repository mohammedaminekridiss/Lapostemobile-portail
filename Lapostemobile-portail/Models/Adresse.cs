using System;
using System.Collections.Generic;

namespace Lapostemobile_portail.Models;

public partial class Adresse
{
    public int IdAdresse { get; set; }

    public int IdPays { get; set; }

    public string? Numero { get; set; }

    public string? Voie { get; set; }

    public string Ville { get; set; } = null!;

    public string Codepostal { get; set; } = null!;

    public string? AdresseComp { get; set; }

    public DateTime? DatCre { get; set; }

    public DateTime? DatMod { get; set; }
}
