namespace Atin.Tests;

public class AtinParserTests
{
    [Fact]
    public void Parse_CombinedTimeFrames()
    {
        string input = "W1D2H3M4S5";

        var result = AtinParser.Parse(input);

        TimeSpan expected = new TimeSpan(9, 3, 4, 5);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Parse_ForSingleDigit()
    {
        string input = "W2";

        TimeSpan result = AtinParser.Parse(input);

        TimeSpan expected = TimeSpan.FromDays(14);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Parse_ForTwoDigits()
    {
        string input = "M10";

        TimeSpan result = AtinParser.Parse(input);

        TimeSpan expected = TimeSpan.FromMinutes(10);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Parse_EmptyString_ZeroTimeSpan()
    {
        string input = "";

        TimeSpan result = AtinParser.Parse(input);

        TimeSpan expected = TimeSpan.Zero;
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Parse_InvalidTimeFrame_Exception()
    {
        string input = "X1";

        Assert.Throws<ArgumentException>(() => AtinParser.Parse(input));
    }

    [Fact]
    public void Parse_InvalidFormat_Exception()
    {
        string input = "W2H";

        Assert.Throws<ArgumentException>(() => AtinParser.Parse(input));
    }

    [Fact]
    public void TryParse_CombinedTimeFrames()
    {
        string input = "W1D2H3M4S5";

        var ok = AtinParser.TryParse(input, out TimeSpan result);

        TimeSpan expected = new(9, 3, 4, 5);
        Assert.True(ok);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void TryParse_ForSingleDigit()
    {
        string input = "W2";

        var ok = AtinParser.TryParse(input, out TimeSpan result);

        TimeSpan expected = TimeSpan.FromDays(14);
        Assert.True(ok);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void TryParse_ForTwoDigits()
    {
        string input = "M10";

        var ok = AtinParser.TryParse(input, out TimeSpan result);

        TimeSpan expected = TimeSpan.FromMinutes(10);
        Assert.True(ok);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void TryParse_EmptyString_ZeroTimeSpan()
    {
        string input = "";

        var ok = AtinParser.TryParse(input, out TimeSpan result);

        TimeSpan expected = TimeSpan.Zero;
        Assert.True(ok);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void TryParse_InvalidTimeFrame_Exception()
    {
        string input = "X1";

        Assert.False(AtinParser.TryParse(input, out _));
    }

    [Fact]
    public void TryParse_InvalidFormat_Exception()
    {
        string input = "W2H";

        Assert.False(AtinParser.TryParse(input, out _));
    }
}