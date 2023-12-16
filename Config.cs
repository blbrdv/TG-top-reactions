namespace tgreacts;

public static class Config
{
    public static readonly string ChannelName = Environment.GetEnvironmentVariable("CHANNEL")!;
    
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