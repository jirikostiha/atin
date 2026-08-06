using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Atin;

/// <summary>
/// Parses alphanumeric time interval notation (e.g. "W1D2H3M4S5") into <see cref="TimeSpan"/>.
/// </summary>
public static class AtinParser
{
    // Matches a unit letter (W/D/H/M/S, case-insensitive) followed by its digits.
    private static readonly Regex _regex = new(@"([WwDdHhMmSs])(\d+)", RegexOptions.Compiled);

    /// <summary>
    /// Parses a time string and returns the equivalent <see cref="TimeSpan"/>.
    /// </summary>
    /// <param name="input">A string representing time intervals (e.g. "W2D3H4").</param>
    /// <returns>A <see cref="TimeSpan"/> representing the total time.</returns>
    /// <exception cref="ArgumentNullException">The input is null.</exception>
    /// <exception cref="ArgumentException">The input format is invalid.</exception>
    public static TimeSpan Parse(string input)
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));

        return TryParseCore(input, throwOnError: true, out var result)
            ? result
            : throw new ArgumentException("Input format is invalid.", nameof(input));
    }

    /// <summary>
    /// Tries to parse the time string.
    /// </summary>
    /// <param name="input">A string representing time intervals (e.g. "W2D3H4").</param>
    /// <param name="result">The output <see cref="TimeSpan"/> if parsing succeeds; otherwise <see cref="TimeSpan.Zero"/>.</param>
    /// <returns><c>true</c> if the input string was successfully parsed; otherwise <c>false</c>.</returns>
    public static bool TryParse(string? input, out TimeSpan result)
    {
        if (input is null)
        {
            result = TimeSpan.Zero;
            return false;
        }

        return TryParseCore(input, throwOnError: false, out result);
    }

    private static bool TryParseCore(string input, bool throwOnError, out TimeSpan result)
    {
        result = TimeSpan.Zero;

        if (input.Length == 0)
            return true;

        if (!char.IsDigit(input[input.Length - 1]))
        {
            if (throwOnError)
                throw new ArgumentException("The last character of the input must be a digit.", nameof(input));
            return false;
        }

        var matches = _regex.Matches(input);
        if (matches.Count == 0)
            return false;

        long totalSeconds = 0;
        foreach (Match match in matches)
        {
            if (!int.TryParse(match.Groups[2].Value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var quantity))
                return false;

            var unit = match.Groups[1].Value[0];
            var unitSeconds = unit switch
            {
                'W' or 'w' => 604800L,
                'D' or 'd' => 86400L,
                'H' or 'h' => 3600L,
                'M' or 'm' => 60L,
                'S' or 's' => 1L,
                _ => -1L,
            };

            if (unitSeconds < 0)
            {
                if (throwOnError)
                    throw new ArgumentException($"Invalid time unit: {unit}", nameof(input));
                return false;
            }

            totalSeconds += quantity * unitSeconds;
        }

        result = TimeSpan.FromSeconds(totalSeconds);
        return true;
    }
}
