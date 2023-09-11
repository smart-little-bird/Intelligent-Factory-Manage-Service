namespace Intelligent.Factory.Management.Domain.Exceptions;

/// <summary>
/// Exception type for domain exceptions
/// </summary>
public class IntelligentFactoryDomainException : Exception
{
    public IntelligentFactoryDomainException()
    { }

    public IntelligentFactoryDomainException(string message)
        : base(message)
    { }

    public IntelligentFactoryDomainException(string message, Exception innerException)
        : base(message, innerException)
    { }
}
