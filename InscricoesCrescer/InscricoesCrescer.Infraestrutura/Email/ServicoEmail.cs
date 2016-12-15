using InscricoesCrescer.Dominio.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace InscricoesCrescer.Infraestrutura.Email
{
    public class ServicoEmail : IServicoEmail
    {
        public bool enviarEmailConfirmacao(string para, string linkConfirmacao)
        {
            // Hotmail                                          gmail
            //smtp.Host = "smtp.live.com";                  smtp.Host = "smtp.gmail.com";
            //smtp.Port = 587;                              smtp.Port = 465;
            //email:rodrigo.scheuer@hotmail.com             email:  emailTesteCwi@gmail.com
            //                                              senha: GAoXIP3tC0Qv
            string assunto = "Confirmação de cadastro no projeto Crescer";
            string mensagem = "Link de confirmação aqui -> ";

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            MailMessage mail = new MailMessage("emailTesteCwi@gmail.com", para, assunto, mensagem);

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
    }
}
