

using JobStack.Application.Common.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;



namespace JobStack.Infrastructure.Services;

public class EmailService : IEmailService
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    #region Sendin blue sen email
    //public void SendEmail(string to, string content)
    //{
    //    var smtpClient = new SmtpClient("smtp-relay.sendinblue.com")
    //    {
    //        Port=587,
    //        Credentials= new NetworkCredential("mahammadvm@code.edu.az", "pCAaNwTQvOLGI8Z3")
    //    };
    //    smtpClient.Send("mahammadvm@code.edu.az", to,"JobStack",content);
    //} 
    #endregion

    #region Smtp send Email
    public void SendEmail(string to, string content)
    {
        var email = new MimeMessage();
        var mm = _configuration["SendApply:Email"];
        var ms = _configuration["SendApply:Password"];
        email.From.Add(MailboxAddress.Parse(mm));
        email.To.Add(MailboxAddress.Parse(to));
        email.Subject = "Excel Project";
        email.Body = new TextPart(TextFormat.Html) { Text = content };
        using (SmtpClient smtp = new())
        {
            smtp.Connect("smtp.office365.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(mm, ms);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
    #endregion
}
