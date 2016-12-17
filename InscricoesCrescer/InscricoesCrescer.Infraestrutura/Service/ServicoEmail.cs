using InscricoesCrescer.Dominio.Email;
using InscricoesCrescer.Infraestrutura.Service;
using System;
using System.Configuration;
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

            /*informações do web.config*/
            string host = buscarConfiguracao("smtpHost");
            int port = Convert.ToInt32(buscarConfiguracao("smtpPort"));
            string email = buscarConfiguracao("email");
            string senha = buscarConfiguracao("senha");
            string assunto = "Confirmação de cadastro no projeto Crescer";
            string mensagem = "Link de confirmação aqui -> " + GerarLink(destinatario);

            SmtpClient smtp = new SmtpClient(host, port);
            MailMessage mail = new MailMessage(email, destinatario, assunto, mensagem);

            smtp.UseDefaultCredentials = true;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new System.Net.NetworkCredential(email, senha);
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
            string servidor = buscarConfiguracao("enderecoServidor");
            string enderecoConfirmacaoEmail = buscarConfiguracao("enderecoConfirmacaoEmail");
            string link = servidor + enderecoConfirmacaoEmail + token;
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

        public static string buscarConfiguracao(string nomeDoCampo)
        {
            try
            {
                var configuracoes = ConfigurationManager.AppSettings;
                string resultado = configuracoes[nomeDoCampo] ?? "campo vazio.";
                return resultado;
            }
            catch (ConfigurationErrorsException)
            {
                return "Error ao ler configurações.";
            }
        }
    }
}
