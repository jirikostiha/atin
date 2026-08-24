# Atin Documentation

**Atin** is a lightweight .NET library for parsing, formatting, and manipulating alphanumeric time interval notations (e.g. `D1`, `H3`, `M5`, `W2H1S10`).

---

## Design Principles

- **Standardized Notation:** Express time spans succinctly using intuitive unit-quantity pairs (`W` for weeks, `D` for days, `H` for hours, `M` for minutes, `S` for seconds).
- **Broad Compatibility:** Targets `netstandard2.0` so it can be consumed seamlessly across .NET Framework, .NET Core, and modern .NET.
- **High Performance:** Allocation-friendly parsing and formatting converting directly to and from standard `System.TimeSpan`.
- **Time Manipulation:** Comprehensive rounding helpers (`RoundTo`, `RoundDown`, `RoundUp`) for both `TimeSpan` and `DateTimeOffset`.

---

## Installation

Install the NuGet package:

```shell
dotnet add package Atin
```

---

## Quick Navigation

- [API Reference](api/index.md) - Full reference documentation for all types and extension methods.
- [GitHub Repository](https://github.com/jirikostiha/atin) - Source code, issues, and discussions.

---

## Overview of Features

| Feature | Description | Key APIs |
| :--- | :--- | :--- |
| **Parsing** | Convert ATIN strings into `TimeSpan` | `AtinParser.Parse`, `AtinParser.TryParse` |
| **Formatting** | Convert `TimeSpan` into standard ATIN string representations | `TimeSpan.ToAtin()` |
| **TimeSpan Rounding** | Round `TimeSpan` up, down, or to nearest interval | `TimeSpan.RoundTo`, `RoundDown`, `RoundUp` |
| **DateTimeOffset Rounding** | Round `DateTimeOffset` timestamps to intervals | `DateTimeOffset.RoundTo`, `RoundDown`, `RoundUp` |
