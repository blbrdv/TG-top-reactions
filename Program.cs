using tgreacts;
using TL;
using Config = tgreacts.Config;

using var client = new WTelegram.Client(Config.Auth);
var myself = await client.LoginUserIfNeeded();

var channel = await client.Channels_GetChannelByUsername(Config.ChannelName);
var history = await client.Messages_GetHistory(channel, 0, default, 0, 0);


Dictionary<MessageBase, int> messages = new();
var step = 0;

while (history.Messages[0].Date >= DateTime.Today.AddYears(-1))
{
    await Task.Delay(500);

    foreach (var message in history.Messages)
    {
        try
        {
            var rec = await client.Messages_GetMessageReactionsList(new InputPeerUser(myself.ID, myself.access_hash),
                message.ID);
            messages.Add(message, rec.count);
        }
        catch (RpcException)
        {
            // This exception happens when
            // message have not reactions
        }
    }

    step += 20;
    history = await client.Messages_GetHistory(channel, 0, default, step, 0);
}

messages = messages
    .OrderBy(x => x.Value)
    .ToDictionary(x => x.Key, x => x.Value);

foreach (var message in messages)
{
    Console.WriteLine($"{message.Value}   https://t.me/{Config.ChannelName}/{message.Key.ID}");
}
