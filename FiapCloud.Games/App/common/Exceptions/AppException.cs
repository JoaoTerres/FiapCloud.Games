namespace FiapCloud.Games.App.common.Exceptions;

public class AppException : Exception
{
    public AppException(string message, Exception? innerException = null)
        : base(message, innerException)
    {
    }
}
