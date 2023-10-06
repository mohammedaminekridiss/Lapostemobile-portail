namespace Lapostemobile_Contrat
{
    public static class ContratPDFService
    {
        public static void GeneratePDFfromhtml()
        {
            var render = new ChromePdfRenderer();
            var pdf = render.RenderHtmlAsPdf("<h1>This is a heading</h1>");
            pdf.SaveAs(@"C:\Users\AK47\Desktop\projetMA\Contrat.pdf");

        }

    }
}