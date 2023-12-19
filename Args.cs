using Utility.CommandLine;

namespace TGTopReactions;

public static class Args
{
    [Argument('i', "id", "Application ID.")]
    public static string ApiId { get; set; } = "";
    
    [Argument('h', "hash", "Application Hash.")]
    public static string ApiHash { get; set; } = "";
    
    [Argument('p', "phone", "Account phone number.")]
    public static string PhoneNumber { get; set; } = "";
    
    [Argument('c', "channel", "Channel name.")]
    public static string ChannelName { get; set; } = "";
    
    [Argument('t', "period", "Period for which messages are parsed.")]
    public static string ParsingPeriod { get; set; } = "1M";
    
    [Argument('r', "reactions", "Reaction count limit.")]
    public static int ReactionCountLimit { get; set; } = 5;
}