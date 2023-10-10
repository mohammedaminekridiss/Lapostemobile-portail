using Lapostemobile_portail.Models;
 
namespace Lapostemobile_Contrat
{
    public static class ContratPDFService
    {
        public static void GeneratePDFfromhtml(int idsouscription)
        {
            using (var dbContext = new PortailContext())
            {
                var prospect = dbContext.Prospects.FirstOrDefault(p => p.IdSouscription == idsouscription);
                var ligne = dbContext.Lignes.FirstOrDefault(l => l.IdSouscription == idsouscription);
                var offre = dbContext.OffreEngagements.FirstOrDefault(o => o.IdOffreEngagement == ligne.IdOffreEngagement);
                var lignearticle = dbContext.LigneArticles.FirstOrDefault(la => la.IdLigne == ligne.IdLigne);
                var article = dbContext.Articles.FirstOrDefault(a => a.IdArticle == lignearticle.IdArticle);
                var carac = dbContext.CaracteristiquesArticles.Where(c => c.IdArticle == lignearticle.IdArticle).ToList();
                var prix = dbContext.PrixArticles.Where(pa => pa.IdOffreEngagement == ligne.IdOffreEngagement && pa.IdArticle == lignearticle.IdArticle).ToList();
                if (article != null && carac != null && offre != null && prix != null && ligne != null && prospect !=null)
                {
                    var render = new ChromePdfRenderer();
            var html = $"<html><head><title>Contrat de Souscription {idsouscription}</title><style>" +
         "body { font-family: Arial, sans-serif ; margin: 0; padding: 0; }" +
         ".container { padding: 20px; display: flex; }" +
         ".container div { flex: 1; padding: 10px; }" +
         "h1 { font-size: 24px; color: #333; text-align: center; }" +
         "h2 { font-size: 20px; color: #444; }" +
         "p { font-size: 16px; color: #666; }" +
         ".image-container { float: left; width: 30%; }" +
         ".image-container img { max-width: 100%; }" +
         ".libelle-article { font-style: italic; text-decoration: underline; }" +
         ".caracteristiques { clear: both; }" +
         "</style></head><body>" +
           $"<h1 class=\"title\">Contrat de Souscription {idsouscription}</h1>" +
            $"<div class=\"prospect-info\">" +
             $"<h2>Informations du Prospect :</h2>" +
                 $"<p><strong>Nom:</strong> {prospect.Nom}</p>" +
                 $"<p><strong>Prénom:</strong> {prospect.Prenom}</p>" +
                 $"<p><strong>Date de Naissance:</strong> {prospect.DateNaissance.ToShortDateString()}</p>" +
                 $"<p><strong>Adresse E-mail:</strong> {prospect.Email}</p>" +
                 $"<p><strong>Numéro de Téléphone Mobile:</strong> {prospect.NumeroMobile}</p>" +
                 $"</div>" +
                 $"<h2>Informations de l'offre et de l'article sélectionnés :</h2>" +
         $"<div class=\"container\">" +
         $"<div class=\"image-container\">" +
         $"<img src=\"C:\\Users\\med kridis\\Desktop\\Angular\\Projet-LaposteMobile-Front\\src\\{article.FichierImage}\" alt=\"{article.LibelleArticle}\">" +
         $"<p class=\"libelle-article\">{article.LibelleArticle}</p>" +
         "</div>" +
         "<div>" +
         "<strong>Caractéristiques articles: </strong><ul>";

                    foreach (var caracItem in carac)
                    {
                        html += $"<li>{caracItem.NomCaracteristiquesArticles}: {caracItem.ValeurCarasteristiquesArticles}</li>";
                    }

                    html += "</ul>" +
                       "</div></div></div>" +
                     $"<p><strong>Nom de l'Offre séléctionnée: </strong> {offre.LibelleMarketing}</p>" +
                    $"<p><strong>Prix de l'Offre séléctionnée: </strong> {offre.Prix} €</p>" +
                    $"<p><strong>Prix de l'Article séléctionné selon cette offre: </strong> {prix[0].PrixArticle1} €</p>" +

                    "</body></html>";



                    var pdf = render.RenderHtmlAsPdf(html);
                    pdf.SaveAs(@"C:\Users\med kridis\Desktop\ContratPDF\Contrat" + idsouscription + ".pdf");
                }

            }
        }
    }
}

