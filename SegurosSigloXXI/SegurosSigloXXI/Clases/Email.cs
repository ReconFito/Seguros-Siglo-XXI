using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;

namespace SegurosSigloXXI.Clases
{
    public class Email
    {
        public Email(string _destinatario)
        {
            this.remitente = "munozfito4@gmail.com";
            this.destinatario = _destinatario;
            this.contrasena = "ee7LELxrebn6VJd";
        }

        #region Enviar correo
        /// <summary>
        /// Enviar correo al nuevo registrado
        /// </summary>
        /// <param name="_nombre"></param>
        /// <param name="_pApellido"></param>
        /// <param name="_sApellido"></param>
        public void EnviaCorreo(string _nombre, string _pApellido, string _sApellido = null)
        {
            MailAddress from = new MailAddress(this.remitente);
            MailAddress to = new MailAddress(this.destinatario);

            MailMessage message = new MailMessage(from, to);
            message.Subject = "Su cuenta en Seguros El Equipo del Siglo XXI";
            message.Body = $"Estimado cliente:\n{_pApellido} {_sApellido} {_nombre}\n" +
                            "\nGracias por confiar en Seguros el Equipo del Siglo XXI." +
                            " Para nosotros es un placer servirles.";

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                // Esablecer credenciales de conección para el adiministrador
                Credentials = new NetworkCredential(this.remitente, this.contrasena),
                EnableSsl = true
            };
            try
            {
                client.Send(message);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }
        #endregion

        private string remitente { get; set; }
        private string destinatario { get; set; }
        private string contrasena { get; set; }
    }
}