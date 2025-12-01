namespace FiapCloud.Games.Domain;

public class DomainException : Exception
{
    public DomainException(string message) : base(message) { }
}
