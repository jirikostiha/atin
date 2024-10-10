using System;
using System.Text;

namespace Atin;

/// <summary>
/// Provides extension methods for the <see cref="TimeSpan"/> class.
/// </summary>
public static class TimeSpanExtensions
{
    /// <summary>
    /// Converts a <see cref="TimeSpan"/> object to a custom formatted string in the "Atin" format.
    /// The format includes weeks (W), days (D), hours (H), minutes (M), and seconds (S).
    /// </summary>
    /// <param name="timeSpan">The <see cref="TimeSpan"/> instance to convert.</param>
    /// <returns>A string representing the time span in the "Atin" format (e.g., "W2D3H4M5S").</returns>
    public static string ToAtin(this TimeSpan timeSpan)
    {
        int totalSeconds = (int)timeSpan.TotalSeconds;

        // Calculate weeks, days, hours, minutes, and seconds from the total seconds.
        int weeks = totalSeconds / 604800; // 604800 seconds in a week
        totalSeconds %= 604800;

        int days = totalSeconds / 86400;   // 86400 seconds in a day
        totalSeconds %= 86400;

        int hours = totalSeconds / 3600;   // 3600 seconds in an hour
        totalSeconds %= 3600;

        int minutes = totalSeconds / 60;   // 60 seconds in a minute
        int seconds = totalSeconds % 60;   // remaining seconds

        // Use StringBuilder to construct the output string.
        var result = new StringBuilder();

        // Append weeks, if any.
        if (weeks > 0)
        {
            result.Append($"W{weeks}");
        }

        // Append days, if any.
        if (days > 0)
        {
            result.Append($"D{days}");
        }

        // Append hours, if any.
        if (hours > 0)
        {
            result.Append($"H{hours}");
        }

        // Append minutes, if any.
        if (minutes > 0)
        {
            result.Append($"M{minutes}");
        }

        // Append seconds or default to seconds if no other units were added.
        if (seconds > 0 || result.Length == 0) // Always include seconds if no other units were added.
        {
            result.Append($"S{seconds}");
        }

        return result.ToString();
    }
}
