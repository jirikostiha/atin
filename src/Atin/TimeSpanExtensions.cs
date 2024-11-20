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

    /// <summary>
    /// Rounds the <see cref="TimeSpan"/> value to the nearest interval.
    /// </summary>
    /// <param name="timeSpan">The original <see cref="TimeSpan"/> to round.</param>
    /// <param name="subInterval">The interval to which the value should be rounded.</param>
    /// <returns>The rounded <see cref="TimeSpan"/>.</returns>
    public static TimeSpan RoundTo(this TimeSpan timeSpan, TimeSpan subInterval)
    {
        long ticks = (timeSpan.Ticks + subInterval.Ticks / 2) / subInterval.Ticks * subInterval.Ticks;
        return TimeSpan.FromTicks(ticks);
    }

    /// <summary>
    /// Rounds the <see cref="TimeSpan"/> value down to the nearest interval.
    /// </summary>
    /// <param name="timeSpan">The original <see cref="TimeSpan"/> to round.</param>
    /// <param name="subInterval">The interval to which the value should be rounded down.</param>
    /// <returns>The rounded-down <see cref="TimeSpan"/>.</returns>
    public static TimeSpan RoundDown(this TimeSpan timeSpan, TimeSpan subInterval)
    {
        long ticks = timeSpan.Ticks / subInterval.Ticks * subInterval.Ticks;
        return TimeSpan.FromTicks(ticks);
    }

    /// <summary>
    /// Rounds the <see cref="TimeSpan"/> value up to the nearest interval.
    /// </summary>
    /// <param name="timeSpan">The original <see cref="TimeSpan"/> to round.</param>
    /// <param name="subInterval">The interval to which the value should be rounded up.</param>
    /// <returns>The rounded-up <see cref="TimeSpan"/>.</returns>
    public static TimeSpan RoundUp(this TimeSpan timeSpan, TimeSpan subInterval)
    {
        long ticks = (timeSpan.Ticks + subInterval.Ticks - 1) / subInterval.Ticks * subInterval.Ticks;
        return TimeSpan.FromTicks(ticks);
    }
}
