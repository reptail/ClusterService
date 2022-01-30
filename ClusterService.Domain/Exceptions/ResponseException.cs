namespace ClusterService.Domain.Exceptions;

public class ResponseException : Exception
{
    public ResponseException(int statusCode, string message)
        : base(message)
    {
        StatusCode = statusCode;
    }

    public ResponseException(int statusCode, string message, Exception innerException)
        : base(message, innerException)
    {
        StatusCode = statusCode;
    }

    public int StatusCode { get; }

    public override string ToString()
        => $"[{StatusCode}] {Message}";
}
