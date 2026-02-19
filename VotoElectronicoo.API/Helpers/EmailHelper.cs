using System.Net;
using System.Net.Mail;

namespace VotoElectronico.API.Helpers
{
    public static class EmailHelper
    {
        public static void Enviar(string destino, string asunto, string mensaje, byte[] pdf)
        {
            var correo = new MailMessage();
            correo.From = new MailAddress("melodycriollo.16@gmail.com");
            correo.To.Add(destino);
            correo.Subject = asunto;
            correo.Body = mensaje;

            correo.Attachments.Add(new Attachment(
                new MemoryStream(pdf),
                "CertificadoVotacion.pdf",
                "application/pdf"
            ));

            var smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(
                    "melodycriollo.16@gmail.com",
                    "hkyjlfqwyuyemxsv"
                ),
                EnableSsl = true
            };

            smtp.Send(correo);
        }
    }
}