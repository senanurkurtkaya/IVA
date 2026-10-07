using Iva.Application.Abstractions;
using OpenAI.Chat;

namespace Iva.Infrastructure.AI;

public sealed class OpenAiService : IAiService
{
    private readonly ChatClient _chatClient;

    public OpenAiService(ChatClient chatClient)
    {
        _chatClient = chatClient;
    }

    public async Task<string> GetResponseAsync(
      string message,
      CancellationToken cancellationToken = default)
    {
        ChatCompletion completion =
            await _chatClient.CompleteChatAsync(
                new ChatMessage[]
                {
                new UserChatMessage(message)
                },
                cancellationToken: cancellationToken);

        return completion.Content[0].Text;
    }
}