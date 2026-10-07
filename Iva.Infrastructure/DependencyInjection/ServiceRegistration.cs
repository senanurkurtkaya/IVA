using Iva.Application.Abstractions;
using Iva.Infrastructure.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenAI.Chat;

namespace Iva.Infrastructure.DependencyInjection;

public static class ServiceRegistration
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var apiKey = configuration["OpenAI:ApiKey"];

        if (string.IsNullOrWhiteSpace(apiKey))
        {
            throw new InvalidOperationException(
                "OpenAI API key bulunamadı.");
        }

        services.AddSingleton(
            new ChatClient(
                model: "gpt-5.1",
                apiKey: apiKey));

        services.AddScoped<IAiService, OpenAiService>();

        return services;
    }
}