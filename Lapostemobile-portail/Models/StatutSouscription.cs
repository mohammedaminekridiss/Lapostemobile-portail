using System;
using System.Collections.Generic;

namespace Lapostemobile_portail.Models;

public partial class StatutSouscription
{
    public int IdStatutSouscription { get; set; }

    public string LibelleStatutSouscription { get; set; } = null!;

    public decimal EstSouscriptionComplete { get; set; }

    public virtual ICollection<Souscription> Souscriptions { get; set; } = new List<Souscription>();
}
