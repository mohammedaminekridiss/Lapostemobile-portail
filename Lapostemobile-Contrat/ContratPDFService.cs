using Lapostemobile_portail.Models;
using Microsoft.EntityFrameworkCore;

namespace Lapostemobile_Contrat
{
    public static class ContratPDFService
    {
    
        public static void GeneratePDFfromhtml(int IdSouscription, int IdArticle, int IdOffreEngagement )
{
    var render = new ChromePdfRenderer();
            var html = $"<h1>Contrat de Souscription</h1>" +
                              $"<p>Souscription ID: {IdSouscription}</p>" +
                              $"<p>ArticleID: {IdArticle} </p>" +
                              $"<p>OffreID: {IdOffreEngagement} </p>";

     
            var pdf = render.RenderHtmlAsPdf(html);
    pdf.SaveAs(@"C:\Users\med kridis\Desktop\ContratPDF\Contrat"+ IdSouscription + ".pdf");
}


    }
}