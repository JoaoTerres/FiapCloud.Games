namespace FiapCloud.Games.App.common.Exceptions;

public class NotFoundException : AppException
{
    public NotFoundException(string entityName, string id)
        : base($"{entityName} não encontrado(a). Id={id}")
    {
    }

    public NotFoundException(string message)
        : base(message)
    {
    }
}
