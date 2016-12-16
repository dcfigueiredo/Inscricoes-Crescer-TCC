using InscricoesCrescer.Dominio.Email;
using InscricoesCrescer.Infraestrutura.Service;
using System;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace InscricoesCrescer.Infraestrutura
{
    public class ServicoEmail : IServicoEmail
    {
        public bool enviarEmailConfirmacao(string destinatario)
        {
            // Hotmail                                          gmail
            //smtp.Host = "smtp.live.com";                  smtp.Host = "smtp.gmail.com";
            //smtp.Port = 587;                              smtp.Port = 465;
            //email:rodrigo.scheuer@hotmail.com             email:  emailTesteCwi@gmail.com  senha: GAoXIP3tC0Qv

            string assunto = "Confirmação de cadastro no projeto Crescer";
            string mensagem = "Link de confirmação aqui -> " + GerarLink(destinatario);

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            MailMessage mail = new MailMessage("emailTesteCwi@gmail.com", destinatario, assunto, mensagem);

            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new System.Net.NetworkCredential("emailTesteCwi@gmail.com", "GAoXIP3tC0Qv");
            //smtp.Timeout = 20000;

            try
            {
                smtp.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                mail.Dispose();
            }
        }

        private string GerarLink(string email)
        {
            ServicoCriptografia servicoCriptografia = new ServicoCriptografia();
            string token = servicoCriptografia.Criptografar(email);
            string link = "http://localhost:64478/Home/ConfirmaCadastro/" + token;
            return link;
        }

        public bool ValidaEmail(string enderecoEmail)
        {
            Regex expressaoRegex = new Regex(@"\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}");

            if (expressaoRegex.IsMatch(enderecoEmail))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
