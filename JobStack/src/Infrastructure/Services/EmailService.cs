

using JobStack.Application.Common.Interfaces;
using System.Net;
using System.Net.Mail;

namespace JobStack.Infrastructure.Services;

public class EmailService : IEmailService
{
    public void SendEmail(string to, string content)
    {
        var smtpClient = new SmtpClient("smtp-relay.sendinblue.com")
        {
            Port=587,
            Credentials= new NetworkCredential("mahammadvm@code.edu.az","")
        };
        smtpClient.Send("",to,"",content);
    }
}
