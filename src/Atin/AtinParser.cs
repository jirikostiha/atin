using System.Text.RegularExpressions;
using System;
using System.Globalization;

namespace Atin;

public static class AtinParser
{
    private const string _regexPattern = @"([WwDdHhMmSs])(\d+)";

    private static readonly Regex _regex = new(_regexPattern, RegexOptions.Compiled);

    public static TimeSpan Parse(string input)
    {
        if (input is null)
        {
            throw new ArgumentNullException(nameof(input));
        }

        if (input == string.Empty)
        {
            return TimeSpan.Zero;
        }

        if (!char.IsDigit(input[input.Length - 1]))
        {
            throw new ArgumentException("The last character of the input must be a digit.");
        }

        var matches = _regex.Matches(input);

        if (matches.Count == 0)
        {
            throw new ArgumentException("Input format is invalid.");
        }

        int totalSeconds = 0;

        foreach (Match match in matches)
        {
            string unit = match.Groups[1].Value;
            int quantity = int.Parse(match.Groups[2].Value, NumberStyles.Integer, CultureInfo.InvariantCulture);

            switch (unit)
            {
                case "W":
                    totalSeconds += quantity * 604800; // Convert weeks to seconds (7 days)
                    break;
                case "D":
                    totalSeconds += quantity * 86400;  // Convert days to seconds (24 hours)
                    break;
                case "H":
                    totalSeconds += quantity * 3600;   // Convert hours to seconds (60 minutes)
                    break;
                case "M":
                    totalSeconds += quantity * 60;    // Convert minutes to seconds
                    break;
                case "S":
                    totalSeconds += quantity;         // Seconds
                    break;
                default:
                    throw new ArgumentException($"Invalid time unit: {unit}");
            }
        }

        return TimeSpan.FromSeconds(totalSeconds);
    }

    public static bool TryParse(string input, out TimeSpan result)
    {
        if (input is null)
        {
            return false;
        }

        if (input == string.Empty)
        {
            result = TimeSpan.Zero;
            return true;
        }

        if (!char.IsDigit(input[input.Length - 1]))
        {
            return false;
        }

        result = TimeSpan.Zero;

        try
        {
            var matches = _regex.Matches(input);

            if (matches.Count == 0)
            {
                return false;
            }

            int totalSeconds = 0;

            foreach (Match match in matches)
            {
                string unit = match.Groups[1].Value;
                int quantity;

                if (!int.TryParse(match.Groups[2].Value, NumberStyles.Integer, CultureInfo.InvariantCulture, out quantity))
                {
                    result = TimeSpan.Zero;
                    return false;
                }

                switch (unit)
                {
                    case "W":
                        totalSeconds += quantity * 604800; // Convert weeks to seconds (7 days)
                        break;
                    case "D":
                        totalSeconds += quantity * 86400;  // Convert days to seconds (24 hours)
                        break;
                    case "H":
                        totalSeconds += quantity * 3600;   // Convert hours to seconds (60 minutes)
                        break;
                    case "M":
                        totalSeconds += quantity * 60;    // Convert minutes to seconds
                        break;
                    case "S":
                        totalSeconds += quantity;         // Seconds
                        break;
                    default:
                        result = TimeSpan.Zero;
                        return false; // Invalid time unit
                }
            }

            result = TimeSpan.FromSeconds(totalSeconds);
            return true;
        }
        catch
        {
            result = TimeSpan.Zero;
            return false;
        }
    }
}
