﻿namespace Lapostemobile_portail.Models;

public partial class ModeLivraison
{
    public int IdModeLivraison { get; set; }

    public string LibelleModeLivraison { get; set; } = null!;

    public int PrixLivraison { get; set; }
}
