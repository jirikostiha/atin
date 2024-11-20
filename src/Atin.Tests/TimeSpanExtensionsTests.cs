namespace Atin.Tests;

public class TimeSpanExtensionsTests
{
    [Fact]
    public void ToAtin_ForMixedTimeFrames()
    {
        TimeSpan timeSpan = new TimeSpan(7, 2, 3, 4);

        string result = timeSpan.ToAtin();

        Assert.Equal("W1H2M3S4", result);
    }

    [Fact]
    public void ToAtin_ForSingleDigit()
    {
        TimeSpan timeSpan = TimeSpan.FromDays(14);

        string result = timeSpan.ToAtin();

        Assert.Equal("W2", result);
    }

    [Fact]
    public void ToAtin_ForTwoDigits()
    {
        TimeSpan timeSpan = TimeSpan.FromMinutes(10);

        string result = timeSpan.ToAtin();

        Assert.Equal("M10", result);
    }

    [Fact]
    public void RoundTo_M5()
    {
        var subInterval = TimeSpan.FromMinutes(5);
        var totalInterval = new TimeSpan(5, 12, 45);

        var result = totalInterval.RoundTo(subInterval);

        Assert.Equal(new TimeSpan(5, 15, 00), result);
    }

    [Fact]
    public void RoundDown_M5()
    {
        var subInterval = TimeSpan.FromMinutes(5);
        var totalInterval = new TimeSpan(5, 12, 45);

        var result = totalInterval.RoundDown(subInterval);

        Assert.Equal(new TimeSpan(5, 10, 00), result);
    }

    [Fact]
    public void RoundUp_M5()
    {
        var subInterval = TimeSpan.FromMinutes(5);
        var totalInterval = new TimeSpan(5, 12, 45);

        var result = totalInterval.RoundUp(subInterval);

        Assert.Equal(new TimeSpan(5, 15, 00), result);
    }
}