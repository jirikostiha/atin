# Alphanumeric Time Interval Notation (ATIN)  

![GitHub repo size](https://img.shields.io/github/repo-size/jirikostiha/atin)
![GitHub code size](https://img.shields.io/github/languages/code-size/jirikostiha/atin)  
[![Build](https://github.com/jirikostiha/atin/actions/workflows/build.yml/badge.svg)](https://github.com/jirikostiha/atin/actions/workflows/build.yml)
[![Code Lint](https://github.com/jirikostiha/atin/actions/workflows/lint-code.yml/badge.svg)](https://github.com/jirikostiha/atin/actions/workflows/lint-code.yml)

## Overview

This project provides utilities for parsing and formatting alphanumeric time intervals like D1, H3, M5, W2H1S10.  


## Features

- **Parse Atin format to TimeSpan**: The `AtinParser.Parse` method converts a string representation of a time span (weeks, days, hours, minutes, seconds) into a `TimeSpan` object.
- **Format TimeSpan to Atin**: The `ToAtin` extension method converts a `TimeSpan` object into a string using the "Atin" format.


## Example Usage

### Parsing a TimeSpan from a string

The following example shows how to use the `AtinParser.Parse` method to convert a formatted string into a `TimeSpan` object.

```csharp
  Console.WriteLine(AtinParser.Parse("W1D2H3M4S5")); // Output: 9.03:04:05
```

### Formatting a TimeSpan to Atin format

Use the `ToAtin` extension method to convert a `TimeSpan` object into an "Atin"-formatted string.

```csharp
  Console.WriteLine(new TimeSpan(9, 3, 4, 5).ToAtin()); // Output: W1D2H3M4S5
```

## Contributing

Feel free to submit issues or pull requests. All contributions are welcome!

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
