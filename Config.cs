namespace tgreacts;

public static class Config
{
    public static readonly string ChannelName = Environment.GetEnvironmentVariable("CHANNEL")!;
    public static readonly int ReactionCountLimit = int.Parse(Environment.GetEnvironmentVariable("LIMIT")!);
    public static readonly int MinutesLimit = int.Parse(Environment.GetEnvironmentVariable("MINUTES")!);
    
    public static string? Auth(string what)
    {
        switch (what)
        {
            case "api_id": return Environment.GetEnvironmentVariable("API_ID");
            case "api_hash": return Environment.GetEnvironmentVariable("API_HASH");
            case "phone_number": return Environment.GetEnvironmentVariable("PHONE");
            case "verification_code": Console.Write("Code: "); return Console.ReadLine();
            default: return null;
        }
    }
}