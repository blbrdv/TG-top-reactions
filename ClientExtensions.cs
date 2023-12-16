using TL;
using WTelegram;

namespace tgreacts;

public static class ClientExtensions
{
    public static async Task<ChatBase> Channels_GetChannelByUsername(this Client client, string username)
    {
        var channels = await client.Messages_GetAllChats();
        return channels.chats
            .First(k => k.Value.MainUsername == username)
            .Value;
    }
}