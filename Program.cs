﻿using tgreacts;
using TL;
using Config = tgreacts.Config;

using var client = new WTelegram.Client(Config.Auth);
var myself = await client.LoginUserIfNeeded();

var channel = await client.Channels_GetChannelByUsername(Config.ChannelName);
var history = await client.Messages_GetHistory(channel, 0, default, 0, 0);


Dictionary<string, int> messages = new();
var step = 0;

while (history.Messages[0].Date >= DateTime.Today.AddYears(-1))
{
    await Task.Delay(1000);

    foreach (var messageBase in history.Messages)
    {
        if (messageBase == null || messageBase.GetType() == typeof(MessageService))
            continue;
        
        var m = (Message)messageBase;
        
        if (m.reactions == null)
            continue;

        var count = m.reactions.results.Sum(x => x.count);

        if (count <= 5)
            continue;
        
        messages.Add($"https://t.me/{Config.ChannelName}/{messageBase.ID}", count);
    }

    step += 20;
    history = await client.Messages_GetHistory(channel, 0, default, step, 0);
}

messages = messages
    .OrderBy(x => x.Value)
    .ToDictionary(x => x.Key, x => x.Value);

foreach (var message in messages)
{
    Console.WriteLine($"{message.Value}  {message.Key}");
}
