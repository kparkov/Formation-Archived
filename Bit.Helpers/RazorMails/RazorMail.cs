using System.IO;
using System.Net.Mail;
using RazorEngine;

namespace Bit.Helpers.RazorMails
{
    public class RazorMail
    {
        public MailMessage MailMessage { get; set; }
        public string RazorTemplatePath { get; set; }
        public object Model { get; set; }

        public RazorMail(MailMessage message, object model, string templatePath)
        {
            MailMessage = message;
            Model = model;
            RazorTemplatePath = templatePath;
            MailMessage.IsBodyHtml = true;
        }

        public MailMessage GetEmail()
        {
            MailMessage.Body = Razor.Parse(File.ReadAllText(RazorTemplatePath), Model);
            return MailMessage;
        }
    }
}