using System.ComponentModel.DataAnnotations;

namespace Utilisateur_Service_App.Models
{
    public class RequeteInscriptionUtilisateur
    {
        [Required(ErrorMessage = "Le champ 'Email' est requis."), EmailAddress(ErrorMessage = "Veuillez saisir une adresse e-mail valide.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le champ 'Mot de passe' est requis."), MinLength(6, ErrorMessage = "Veuillez entrer au moins 6 caractères, mon ami !")]
        public string MotDePasse { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le champ 'Confirmer le mot de passe' est requis."), Compare("MotDePasse", ErrorMessage = "Les mots de passe ne correspondent pas.")]
        public string ConfirmerMotDePasse { get; set; } = string.Empty;
    }

}
