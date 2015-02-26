using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using Bit.Helpers.Configuration;

namespace Bit.Helpers.RazorMails
{
    public class RazorMailHub
    {
        public SmtpClient SmtpClient { get; set; }

        public RazorMailHub()
        {
        }

        public RazorMailHub(SmtpClient client)
        {
            SmtpClient = client;
        }

        public void LoadSmtpConfiguration()
        {
            SmtpClient = new SmtpClient();

            var configuration = Conf.Get("Bit.RazorMail");

            SmtpClient.Host = configuration.Key<string>("Host");
            SmtpClient.Port = configuration.KeyOrDefault<int>("Port", 25);

            SmtpClient.EnableSsl = configuration.KeyOrDefault("EnableSsl", false);

            var username = configuration.KeyOrDefault<string>("Username");

            if (username != null)
            {
                var user = username;
                var pass = configuration.Key<string>("Password");
                SmtpClient.Credentials = new NetworkCredential(user, pass);
            }
        }

        public void Send(RazorMail mail)
        {
            Send(new[] { mail });
        }

        public void Send(IEnumerable<RazorMail> mails)
        {
            foreach (var mail in mails)
            {
                SmtpClient.Send(mail.GetEmail());
            }
        }
    }
}
