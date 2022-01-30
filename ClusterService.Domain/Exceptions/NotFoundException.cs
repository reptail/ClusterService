namespace ClusterService.Domain.Exceptions;

public class NotFoundException : ResponseException
{
    public NotFoundException(string message)
        : base(404, message)
    {
    }

    public NotFoundException(string message, Exception innerException)
        : base(404, message, innerException)
    {
    }
}
