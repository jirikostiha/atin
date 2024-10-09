using System.Text.RegularExpressions;
using System;
using System.Globalization;

namespace Atin
{
    /// <summary>
    /// A static class that provides methods to parse time span input strings.
    /// </summary>
    public static class AtinParser
    {
        /// <summary>
        /// Regular expression pattern used to match time units (W, D, H, M, S) and corresponding quantities.
        /// </summary>
        private const string _regexPattern = @"([WwDdHhMmSs])(\d+)";

        /// <summary>
        /// Compiled regular expression based on the <see cref="_regexPattern"/>.
        /// </summary>
        private static readonly Regex _regex = new(_regexPattern, RegexOptions.Compiled);

        /// <summary>
        /// Parses a time string and returns the equivalent <see cref="TimeSpan"/> object.
        /// </summary>
        /// <param name="input">A string representing time intervals (e.g., "2W3D4H").</param>
        /// <returns>A <see cref="TimeSpan"/> representing the total time.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the input is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the input format is invalid or the last character is not a digit.</exception>
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

        /// <summary>
        /// Tries to parse the time string and returns a boolean indicating success or failure.
        /// </summary>
        /// <param name="input">A string representing time intervals (e.g., "2W3D4H").</param>
        /// <param name="result">The output <see cref="TimeSpan"/> if parsing succeeds.</param>
        /// <returns><c>true</c> if the input string was successfully parsed; otherwise, <c>false</c>.</returns>
        public static bool TryParse(string input, out TimeSpan result)
        {
            if (input is null)
            {
                result = TimeSpan.Zero;
                return false;
            }

            if (input == string.Empty)
            {
                result = TimeSpan.Zero;
                return true;
            }

            if (!char.IsDigit(input[input.Length - 1]))
            {
                result = TimeSpan.Zero;
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
}
