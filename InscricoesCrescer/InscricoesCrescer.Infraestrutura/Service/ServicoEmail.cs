using InscricoesCrescer.Dominio.Candidato;
using InscricoesCrescer.Dominio.Email;
using InscricoesCrescer.Infraestrutura.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace InscricoesCrescer.Infraestrutura
{
    public class ServicoEmail : IServicoEmail
    {
        /*informações do web.config*/
        private string host = buscarConfiguracao("smtpHost");
        private int port = Convert.ToInt32(buscarConfiguracao("smtpPort"));
        private string email = buscarConfiguracao("email");
        private string senha = buscarConfiguracao("senha");

        public bool enviarEmailConfirmacao(string destinatario)
        {
            string assunto = "Confirmação de cadastro no projeto Crescer";
            string direcionarParaPagina = "/Home/ConfirmaCadastro/";

            string mensagem = "Confirme seu e-mail e aguarde um proximo contato. " + "\n" +
                              " Link de confirmação aqui -> " + GerarLink(destinatario, direcionarParaPagina);

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

        public bool enviarEmailDeNotificacao(List<CandidatoEntidade> listaCandidatos, DateTime dataInicio, DateTime dataFim)
        {
            string assunto = "Abertura do Processo Seletivo CWI";
            string direcionarParaPagina = "/Home/SegundaEtapaCadastroCandidato/";

            foreach (var item in listaCandidatos)
            {
                string mensagem = "Data do Processo Seletivo: " + dataInicio.ToString("dd/MM/yyyy") + "  até  " +
                                   dataFim.ToString("dd/MM/yyyy") + "\n Se você deseja participar confirme seu cadastro aqui -> " +
                                   GerarLink(item.Email, direcionarParaPagina);

                SmtpClient smtp = new SmtpClient(host, port);
                MailMessage mail = new MailMessage(email, item.Email, assunto, mensagem);

                smtp.UseDefaultCredentials = true;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new System.Net.NetworkCredential(email, senha);
                
                try
                {
                    smtp.Send(mail);
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
            return true;
        }

        private string GerarLink(string email, string endereco)
        {
            ServicoCriptografia servicoCriptografia = new ServicoCriptografia();
            string token = servicoCriptografia.Criptografar(email);
            string servidor = buscarConfiguracao("enderecoServidor");
            string link = servidor + endereco + token;
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
