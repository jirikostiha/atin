using System;

namespace Atin;

/// <summary>
/// Provides extension methods for the <see cref="DateTimeOffset"/> class.
/// </summary>
public static class DateTimeOffsetExtensions
{
    /// <summary>
    /// Round dateTime value to begin or end of interval.
    /// </summary>
    public static DateTimeOffset RoundTo(this DateTimeOffset dateTime, TimeSpan interval)
    {
        long ticks = (dateTime.Ticks + interval.Ticks / 2) / interval.Ticks * interval.Ticks;
        return new DateTimeOffset(ticks, dateTime.Offset);
    }

    /// <summary>
    /// Round dateTime value to begin of the interval.
    /// </summary>
    public static DateTimeOffset RoundDown(this DateTimeOffset dateTime, TimeSpan interval)
    {
        long ticks = dateTime.Ticks / interval.Ticks * interval.Ticks;
        return new DateTimeOffset(ticks, dateTime.Offset);
    }

    /// <summary>
    /// Round dateTime value to end of the interval.
    /// </summary>
    public static DateTimeOffset RoundUp(this DateTimeOffset dateTime, TimeSpan interval)
    {
        long ticks = (dateTime.Ticks + interval.Ticks - 1) / interval.Ticks * interval.Ticks;
        return new DateTimeOffset(ticks, dateTime.Offset);
    }
}
