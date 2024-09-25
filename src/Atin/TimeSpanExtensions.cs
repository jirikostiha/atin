using System;
using System.Text;

namespace Atin;

public static class TimeSpanExtensions
{
    public static string ToAtin(this TimeSpan timeSpan)
    {
        int totalSeconds = (int)timeSpan.TotalSeconds;

        int weeks = totalSeconds / 604800; // 604800 seconds in a week
        totalSeconds %= 604800;

        int days = totalSeconds / 86400;   // 86400 seconds in a day
        totalSeconds %= 86400;

        int hours = totalSeconds / 3600;   // 3600 seconds in an hour
        totalSeconds %= 3600;

        int minutes = totalSeconds / 60;   // 60 seconds in a minute
        int seconds = totalSeconds % 60;   // remaining seconds

        var result = new StringBuilder();

        if (weeks > 0)
        {
            result.Append($"W{weeks}");
        }

        if (days > 0)
        {
            result.Append($"D{days}");
        }

        if (hours > 0)
        {
            result.Append($"H{hours}");
        }

        if (minutes > 0)
        {
            result.Append($"M{minutes}");
        }

        if (seconds > 0 || result.Length == 0) // Always include seconds if no other units were added
        {
            result.Append($"S{seconds}");
        }

        return result.ToString();
    }
}
