namespace Atin.Tests;

public class DateTimeOffsetExtensionsTests
{
    [Fact]
    public void RoundTo_M5()
    {
        var timeSpan = TimeSpan.FromMinutes(5);
        var dateTime = new DateTimeOffset(2024, 01, 14, 5, 12, 45, default);

        var result = dateTime.RoundTo(timeSpan);

        Assert.Equal(new DateTimeOffset(2024, 01, 14, 5, 15, 00, default), result);
    }

    [Fact]
    public void RoundDown_M5()
    {
        var timeSpan = TimeSpan.FromMinutes(5);
        var dateTime = new DateTimeOffset(2024, 01, 14, 5, 12, 45, default);

        var result = dateTime.RoundDown(timeSpan);

        Assert.Equal(new DateTimeOffset(2024, 01, 14, 5, 10, 00, default), result);
    }

    [Fact]
    public void RoundUp_M5()
    {
        var timeSpan = TimeSpan.FromMinutes(5);
        var dateTime = new DateTimeOffset(2024, 01, 14, 5, 12, 45, default);

        var result = dateTime.RoundUp(timeSpan);

        Assert.Equal(new DateTimeOffset(2024, 01, 14, 5, 15, 00, default), result);
    }
}