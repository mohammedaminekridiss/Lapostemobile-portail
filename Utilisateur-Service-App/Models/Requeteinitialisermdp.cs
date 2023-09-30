using System.ComponentModel.DataAnnotations;

namespace Utilisateur_Service_App.Models
{
    public class Requeteinitialisermdp
    {
          
            [Required]
            public string Token { get; set; } = string.Empty;
            [Required, MinLength(6, ErrorMessage = "s'il te plait , taper au moins 6 characteres!")]
            public string Mdp { get; set; } = string.Empty;
            [Required, Compare("Mdp")]
            public string confirmerMdp { get; set; } = string.Empty;
        
    }
}
