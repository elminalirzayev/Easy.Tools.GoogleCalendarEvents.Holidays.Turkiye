# Easy.Tools.GoogleCalendarEvents

This package allows you to retrieve public holiday events from [Google Public Calendars](https://developers.google.com/calendar) for Turkey.

It uses Google Calendar API (v3) and provides a clean interface for fetching holiday data based on language preference.

---

## Installation

Install via NuGet:

dotnet add package Easy.Tools.GoogleCalendarEvents


---

## Requirements

* Google API Key (with Calendar API enabled)
* Internet access for fetching calendar data

---

## Usage

### Fetch Turkish Holidays


var service = new HolidayService("YOUR_GOOGLE_API_KEY");
var holidays = await service.GetHolidaysAsync(CalendarLanguage.Turkish);

foreach (var item in holidays)
{
    Console.WriteLine(item);
}


---

## Language Support

Supported calendar languages:

* `CalendarLanguage.Turkish` → `tr.turkish#holiday@group.v.calendar.google.com`
* `CalendarLanguage.English` → `en.turkish.official#holiday@group.v.calendar.google.com`

---

## Testing

Unit tests are located under `Easy.Tools.GoogleCalendarEvents.Tests`.
You can run the tests via:

```bash
dotnet test
```

---

## Notes

* Calendar IDs are internally mapped using `CalendarLanguage` enum.
* API key is injected via constructor and never exposed.
* Uses `HttpClient` internally – override or inject your own instance if needed.

---

## License

MIT

---

© 2025 Elmin Alirzayev / Easy Code Tools
