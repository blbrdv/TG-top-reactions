using tgreacts;
using TL;
using Config = tgreacts.Config;

using var client = new WTelegram.Client(Config.Auth);
var _ = await client.LoginUserIfNeeded();

var channel = await client.Channels_GetChannelByUsername(Config.ChannelName);
var history = await client.Messages_GetHistory(channel, 0, default, 0, 0);


Dictionary<string, int> messages = new();
var step = 0;

while (history.Messages[0].Date >= DateTime.Today.AddMinutes(-Config.MinutesLimit))
{
    await Task.Delay(1000);

    foreach (var messageBase in history.Messages)
    {
        if (messageBase == null || messageBase.GetType() == typeof(MessageService))
            continue;
        
        var message = (Message)messageBase;
        
        if (message.reactions == null)
            continue;

        var count = message.reactions.results.Sum(x => x.count);

        if (count <= Config.ReactionCountLimit)
            continue;
        
        messages.Add($"https://t.me/{Config.ChannelName}/{messageBase.ID}", count);
    }

    step += 20;
    history = await client.Messages_GetHistory(channel, 0, default, step, 0);
}

messages = messages
    .OrderByDescending(x => x.Value)
    .ToDictionary(x => x.Key, x => x.Value);

foreach (var message in messages)
{
    Console.WriteLine($"{message.Value}  {message.Key}");
}
