namespace FiapCloud.Games.App.common.Exceptions;

public class ValidationException : AppException
{
    public ValidationException(string message)
        : base(message)
    {
    }
}
