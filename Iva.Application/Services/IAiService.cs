namespace Iva.Application.Abstractions;

public interface IAiService
{
    Task<string> GetResponseAsync(
        string message,
        CancellationToken cancellationToken = default);
}