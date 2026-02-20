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
                    page.Size(PageSizes.A4);
                    page.Margin(40);

                    // ENCABEZADO
                    page.Header().Column(header =>
                    {
                        header.Item().AlignCenter().Text("REPÚBLICA DEL ECUADOR")
                            .FontSize(16)
                            .Bold();

                        header.Item().AlignCenter().Text("CONSEJO NACIONAL ELECTORAL")
                            .FontSize(14);

                        header.Item().PaddingTop(10).LineHorizontal(1);
                    });

                    // CONTENIDO PRINCIPAL
                    page.Content().Column(col =>
                    {
                        col.Spacing(20);

                        // TITULO
                        col.Item().AlignCenter().Text("CERTIFICADO DE VOTACIÓN")
                            .FontSize(28)
                            .Bold()
                            .FontColor(Colors.Blue.Medium);

                        col.Item().AlignCenter().Text("Sistema de Voto Electrónico")
                            .FontSize(14)
                            .FontColor(Colors.Grey.Darken1);

                        col.Item().PaddingVertical(10).LineHorizontal(1);

                        // TEXTO INTRODUCTORIO
                        col.Item().Text("El Consejo Nacional Electoral certifica que el ciudadano:")
                            .FontSize(14);

                        // CUADRO DATOS
                        col.Item().Background(Colors.Grey.Lighten3).Padding(15).Column(info =>
                        {
                            info.Spacing(10);

                            info.Item().Text($"NOMBRES: {nombres}")
                                .FontSize(16)
                                .Bold();

                            info.Item().Text($"APELLIDOS: {apellidos}")
                                .FontSize(16)
                                .Bold();

                            info.Item().Text($"CÉDULA: {cedula}")
                                .FontSize(16)
                                .Bold();
                        });

                        // TEXTO LEGAL
                        col.Item().Text("Ha cumplido con su derecho constitucional al voto en el proceso electoral vigente, conforme a lo establecido por la normativa electoral del país.")
                            .FontSize(14);

                        // FECHA
                        col.Item().PaddingTop(20).Text($"Fecha de emisión: {DateTime.UtcNow:dd/MM/yyyy}")
                            .FontSize(12);

                        // FIRMA
                        col.Item().PaddingTop(40).AlignCenter().Column(firma =>
                        {
                            firma.Item().Text("____________________________")
                                .FontSize(12);

                            firma.Item().Text("Consejo Nacional Electoral")
                                .FontSize(12)
                                .Bold();
                        });
                    });

                    // PIE
                    page.Footer().AlignCenter().Text(text =>
                    {
                        text.Span("Documento generado por el Sistema de Voto Electrónico Ecuador")
                            .FontSize(10);
                    });
                });
            }).GeneratePdf();
        }
    }
}