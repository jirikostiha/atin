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
}