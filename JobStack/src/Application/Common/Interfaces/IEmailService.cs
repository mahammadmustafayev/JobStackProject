

namespace JobStack.Application.Common.Interfaces;

public interface IEmailService
{
    void SendEmail(string to,string content);
}
