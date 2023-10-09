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
                    var html = $"<html><head><title>Contrat de Souscription {IdSouscription}</title></head><body>" +
              $"<h1>Contrat de Souscription {IdSouscription}</h1>" +
              $"<table>" +
              $"<tr><td rowspan=\"3\"><img src=\"C:\\Users\\med kridis\\Desktop\\Angular\\Projet-LaposteMobile-Front\\src\\{article.FichierImage}\" alt=\"{article.LibelleArticle}\"></td>" +
              $"<td>Nom de l'Offre:</td><td>{offre.LibelleMarketing}</td></tr>" +
              $"<tr><td>Prix de l'Offre:</td><td>{offre.Prix} €</td></tr>" +
              $"<tr><td>Article:</td><td>{article.LibelleArticle}</td></tr>" +
              "</table>" +
              "<h2>Prix de l'article Selon l'Offre:</h2><ul>";

                    foreach (var prixItem in prix)
                    {
                        html += $"<li>{prixItem.PrixArticle1} €</li>";
                    }

                    html += "</ul><h2>Caractéristiques articles:</h2><table>";

                    foreach (var caracItem in carac)
                    {
                        html += $"<tr><td>{caracItem.NomCaracteristiquesArticles}</td><td>{caracItem.ValeurCarasteristiquesArticles}</td></tr>";
                    }

                    html += "</table></body></html>";

                    var pdf = render.RenderHtmlAsPdf(html);
                    pdf.SaveAs(@"C:\Users\med kridis\Desktop\ContratPDF\Contrat" + IdSouscription + ".pdf");
                }

            }
        }
    }
}

