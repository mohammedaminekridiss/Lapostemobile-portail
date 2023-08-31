using System;
using System.Collections.Generic;

namespace Lapostemobile_portail.Models;

public partial class LigneOption
{
    public int IdLigneOption { get; set; }

    public int IdLigne { get; set; }

    public int? IdOption { get; set; }

    public int PrixVenteOption { get; set; }

    public DateTime? DateCreation { get; set; }

    public DateTime? DatMod { get; set; }

    public virtual Ligne IdLigneNavigation { get; set; } = null!;

    public virtual Option? IdOptionNavigation { get; set; }
}
