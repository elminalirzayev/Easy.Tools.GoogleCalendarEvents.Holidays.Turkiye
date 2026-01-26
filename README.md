[![Build & Test](https://github.com/elminalirzayev/Easy.Tools.GoogleCalendarEvents.Holidays.Turkiye/actions/workflows/build.yml/badge.svg)](https://github.com/elminalirzayev/Easy.Tools.GoogleCalendarEvents.Holidays.Turkiye/actions/workflows/build.yml)
[![Build & Release](https://github.com/elminalirzayev/Easy.Tools.GoogleCalendarEvents.Holidays.Turkiye/actions/workflows/release.yml/badge.svg)](https://github.com/elminalirzayev/Easy.Tools.GoogleCalendarEvents.Holidays.Turkiye/actions/workflows/release.yml)
[![Build & Nuget Publish](https://github.com/elminalirzayev/Easy.Tools.GoogleCalendarEvents.Holidays.Turkiye/actions/workflows/nuget.yml/badge.svg)](https://github.com/elminalirzayev/Easy.Tools.GoogleCalendarEvents.Holidays.Turkiye/actions/workflows/nuget.yml)
[![Release](https://img.shields.io/github/v/release/elminalirzayev/Easy.Tools.GoogleCalendarEvents.Holidays.Turkiye)](https://github.com/elminalirzayev/Easy.Tools.GoogleCalendarEvents.Holidays.Turkiye/releases)
[![License](https://img.shields.io/github/license/elminalirzayev/Easy.Tools.GoogleCalendarEvents.Holidays.Turkiye)](https://github.com/elminalirzayev/Easy.Tools.GoogleCalendarEvents.Holidays.Turkiye/blob/master/LICENSE.txt)
[![NuGet](https://img.shields.io/nuget/v/Easy.Tools.GoogleCalendarEvents.Holidays.Turkiye.svg)](https://www.nuget.org/packages/Easy.Tools.GoogleCalendarEvents.Holidays.Turkiye)

# Easy.Tools.GoogleCalendarEvents.Holidays.Turkiye

A dedicated .NET library for fetching **Official Public Holidays of Turkey (Türkiye Resmi Tatilleri)** directly from Google Calendar.

> This library is an extension of [Easy.Tools.GoogleCalendarEvents](https://www.nuget.org/packages/Easy.Tools.GoogleCalendarEvents).

## Features

- **Zero Configuration:** No need to hunt for Calendar IDs.
- **Multi-Language Support:** Fetch holiday names in **Turkish** (default) or **English**.
- **Always Up-to-Date:** Uses Google's official holiday calendar data.
- **Strongly Typed:** Easy configuration using `HolidayLanguage` enum.
- **Backward Compatible:** Includes legacy support for older versions.

## Installation

Install via NuGet Package Manager Console:
```powershell
Install-Package Easy.Tools.GoogleCalendarEvents.Holidays.Turkiye
```
Or via .NET CLI:

```powershell
dotnet add package Easy.Tools.GoogleCalendarEvents.Holidays.Turkiye
```
## Usage

### 1. Basic Usage (Turkish Default)

By default, the service returns holiday names in Turkish (e.g., "Ramazan Bayramı").

```csharp
using Easy.Tools.GoogleCalendarEvents.Holidays.Turkiye.Services;

var apiKey = "YOUR_GOOGLE_API_KEY";

// Initialize the service
var service = new TurkeyHolidaysService(apiKey);

// Fetch holidays
var holidays = await service.GetHolidaysAsync();

Console.WriteLine($"Found {holidays.Count} holidays:");
foreach (var h in holidays)
{
    Console.WriteLine($"- {h.Summary} ({h.Start.Date})");
}
// Output: "- Ramazan Bayramı (2025-03-30)"
```

### 2. English Names Support

You can explicitly request holiday names in English (e.g., "Ramadan Feast") using the `HolidayLanguage` enum.
```csharp
using Easy.Tools.GoogleCalendarEvents.Holidays.Turkiye.Services;
using Easy.Tools.GoogleCalendarEvents.Holidays.Turkiye.Enums;

var apiKey = "YOUR_GOOGLE_API_KEY";
var service = new TurkeyHolidaysService(apiKey);

// Fetch holidays in English
var holidays = await service.GetHolidaysAsync(HolidayLanguage.English);

foreach (var h in holidays)
{
    Console.WriteLine($"- {h.Summary} ({h.Start.Date})");
}
// Output: "- Ramadan Feast (2025-03-30)"
```

### 3. Dependency Injection (ASP.NET Core)

Designed for seamless integration with `HttpClientFactory`.
```csharp
using Easy.Tools.GoogleCalendarEvents.Holidays.Turkiye.Services;
// Program.cs
using Easy.Tools.GoogleCalendarEvents.Holidays.Turkiye.Services;

builder.Services.AddHttpClient<TurkeyHolidaysService>(client =>
{
    // Optional: Configure timeouts or headers
});

builder.Services.AddSingleton(sp => 
    new TurkeyHolidaysService("YOUR_API_KEY", sp.GetRequiredService<HttpClient>()));
```

##  Migration Guide (v1.x -> v1.1+)

If you were using the older `HolidayService` class, **your code will still work** but you will see a deprecation warning.

-   **Old Class:** `HolidayService` (Marked as Obsolete)
    
-   **New Class:** `TurkeyHolidaysService`
    

We recommend updating your code to use `TurkeyHolidaysService` for better naming clarity and future support.


## 🇹🇷 Covered Holidays

Includes all official public holidays in Turkey:


## Requirements

-   .NET 6.0+, .NET Standard 2.0+, or .NET Framework 4.7.2+
    
-   A valid Google API Key

-   Internet access for fetching calendar data


## License

This project is licensed under the MIT License.

---

© 2025 Elmin Alirzayev / Easy Code Tools
