using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace VotoElectronicoo.API.Helpers
{
    public class PdfHelper
    {
        public static byte[] GenerarCertificado(string nombres, string apellidos, string cedula)
        {
            return Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Content().Column(col =>
                    {
                        col.Item().Text("CERTIFICADO DE VOTACIÓN")
                            .FontSize(22).Bold();

                        col.Item().Text($"Nombres: {nombres}");
                        col.Item().Text($"Apellidos: {apellidos}");
                        col.Item().Text($"Cédula: {cedula}");

                        col.Item().Text("Ha cumplido con su derecho al voto.")
                            .FontSize(14);
                    });
                });
            }).GeneratePdf();
        }
    }
}