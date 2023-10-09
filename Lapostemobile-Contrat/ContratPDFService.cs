using Lapostemobile_portail.Models;
using Microsoft.EntityFrameworkCore;

namespace Lapostemobile_Contrat
{
    public static class ContratPDFService
    {
        public static void GeneratePDFfromhtml(int IdSouscription, int IdArticle, int IdOffreEngagement)
        {
            using (var dbContext = new PortailContext())
            {
                var article = dbContext.Articles.FirstOrDefault(a => a.IdArticle == IdArticle);
                var carac = dbContext.CaracteristiquesArticles.Where(c => c.IdArticle == IdArticle).ToList();
                var offre = dbContext.OffreEngagements.FirstOrDefault(o => o.IdOffreEngagement == IdOffreEngagement);
                var prix = dbContext.PrixArticles.Where(pa => pa.IdOffreEngagement == IdOffreEngagement && pa.IdArticle == IdArticle).ToList();
                if (article != null && carac != null && offre != null && prix != null)
                {
                    var render = new ChromePdfRenderer();
                    var html = $"<html><head><title>Contrat de Souscription {IdSouscription}</title><style>" +
         "body { font-family: Arial, sans-serif ; margin: 0; padding: 0; }" +
         ".page { margin: 20px; border: 2px solid #000; background-color: #ffffff; }" +
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
         $"<h1>Contrat de Souscription {IdSouscription}</h1>" +
         $"<div class=\"page\">" +
         $"<div class=\"container\">" +
         $"<div class=\"image-container\">" +
         $"<img src=\"C:\\Users\\med kridis\\Desktop\\Angular\\Projet-LaposteMobile-Front\\src\\{article.FichierImage}\" alt=\"{article.LibelleArticle}\">" +
         $"<p class=\"libelle-article\">{article.LibelleArticle}</p>" +
         "</div>" +
         "<div>" +
         "<h2>Caractéristiques articles</h2><ul>";

                    foreach (var caracItem in carac)
                    {
                        html += $"<li>{caracItem.NomCaracteristiquesArticles}: {caracItem.ValeurCarasteristiquesArticles}</li>";
                    }

                    html += "</ul>" +
                        $"<p>Nom de l'Offre : <span class=\"libelle-offre\">{offre.LibelleMarketing}</span></p>" +
                        $"<p>Prix de l'Offre : {offre.Prix} €</p>" +
                        $"<p>Prix de l'article : {prix[0].PrixArticle1} €</p>" +
                        "</div></div></div></body></html>";


                    var pdf = render.RenderHtmlAsPdf(html);
                    pdf.SaveAs(@"C:\Users\med kridis\Desktop\ContratPDF\Contrat" + IdSouscription + ".pdf");
                }

            }
        }
    }
}

