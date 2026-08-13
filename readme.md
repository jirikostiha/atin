<p align="center">
  <img src="src/Atin/icon.png" alt="ATIN" width="50"/>
</p>

# Alphanumeric Time Interval Notation (ATIN)

![GitHub repo size](https://img.shields.io/github/repo-size/jirikostiha/atin)
![GitHub code size](https://img.shields.io/github/languages/code-size/jirikostiha/atin)
![Nuget](https://img.shields.io/nuget/dt/Atin)  
[![Build](https://github.com/jirikostiha/atin/actions/workflows/build.yml/badge.svg)](https://github.com/jirikostiha/atin/actions/workflows/build.yml)
[![Code Lint](https://github.com/jirikostiha/atin/actions/workflows/lint-code.yml/badge.svg)](https://github.com/jirikostiha/atin/actions/workflows/lint-code.yml)

## Overview

`Atin` is a small .NET library for parsing and formatting alphanumeric time intervals such as `D1`, `H3`, `M5`, `W2H1S10`.

## Target framework

The library targets `netstandard2.0`, so it can be consumed from .NET Framework, .NET Core, and modern .NET alike.

## Features

- **Parse ATIN to `TimeSpan`** — `AtinParser.Parse` / `AtinParser.TryParse` convert a string representation (weeks, days, hours, minutes, seconds) into a `TimeSpan`.
- **Format `TimeSpan` to ATIN** — the `ToAtin` extension method converts a `TimeSpan` into the ATIN string form.
- **Rounding helpers** — `RoundTo` / `RoundDown` / `RoundUp` extensions on `TimeSpan` and `DateTimeOffset`.

## Example Usage

### Parse

```csharp
Console.WriteLine(AtinParser.Parse("H2"));           // Output: 02:00:00
Console.WriteLine(AtinParser.Parse("W1D2H3M4S5"));   // Output: 9.03:04:05

if (AtinParser.TryParse("D3H4", out var ts))
{
    Console.WriteLine(ts); // 3.04:00:00
}
```

### Format

```csharp
Console.WriteLine(TimeSpan.FromHours(2).ToAtin());     // Output: H2
Console.WriteLine(new TimeSpan(9, 3, 4, 5).ToAtin());  // Output: W1D2H3M4S5
```

### Round

```csharp
var five = TimeSpan.FromMinutes(5);
var ts   = new TimeSpan(5, 12, 45);

ts.RoundTo(five);   // 05:15:00
ts.RoundDown(five); // 05:10:00
ts.RoundUp(five);   // 05:15:00
```

## License

MIT — see the [LICENSE](LICENSE) file.
