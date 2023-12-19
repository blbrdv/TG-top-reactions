namespace TGTopReactions;

public static class PeriodParser
{
    public static int Parse(string rawPeriod)
    {
        var period = 0;
        var currentValue = 0;

        if (string.IsNullOrEmpty(rawPeriod))
        {
            return 0;
        }
        
        foreach (var @char in rawPeriod)
        {
            if (char.IsDigit(@char))
            {
                currentValue = currentValue * 10 + (@char - '0');
            }
            else
            {
                period += @char switch
                {
                    'y' => currentValue * 525600,
                    'M' => currentValue * 43800,  //months
                    'd' => currentValue * 1440,
                    'h' => currentValue * 60,
                    'm' => currentValue,          //minutes
                    _ => throw new ArgumentException("Invalid time unit")
                };

                currentValue = 0;
            }
        }
        
        return period;
    }
}