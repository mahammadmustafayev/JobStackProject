

namespace JobStack.Application.Common.Exceptions;

public class FileException : Exception
{
    public FileException():base("This image must be better than 230 kb")
    {
    }

    public FileException(string? message) : base(message)
    {
    }

    public FileException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
