using System.ComponentModel.DataAnnotations;

namespace Utilisateur_Service_App.Models
{
    public class requeteconnexionutilisateur
    
        {
            [Required, EmailAddress]
            public string Email { get; set; } = string.Empty;
            [Required]
            public string MotDePasse { get; set; } = string.Empty;
        }
    
}
