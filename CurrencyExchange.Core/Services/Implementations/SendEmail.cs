using System;
using System.Net;
using System.Net.Mail;
using CurrencyExchange.Core.Services.Interfaces;

namespace CurrencyExchange.Core.Services.Implementations
{
    public class SendEmail : IMailSender
    {
        public void Send(string to, string subject, string body)
        {
            try

            {
                var defaultEmail = "ali.aen110@gmail.com";
                using (var mail = new MailMessage())
                {
                    mail.From = new MailAddress(defaultEmail, "سیستم مدیریت فروش ارز , نوشته شده توسط علی نایینی");
                    mail.To.Add(to);
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = true;

                    using (var client = new SmtpClient("smtp.gmail.com"))
                    {
                        client.Port = 587;
                        client.Credentials = new NetworkCredential(defaultEmail, "alinaeini4174");
                        client.EnableSsl = true;
                       // client.UseDefaultCredentials = fas;
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.Send(mail);
                    }
                }


            }

            catch (Exception ex)

            {


                string errorMessage = ex.Message.ToString();


            }


        }


    }
}

