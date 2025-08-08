using Easy.Tools.GoogleCalendarEvents.Holidays.Turkiye.Enum;
using Easy.Tools.GoogleCalendarEvents.Holidays.Turkiye.Value;
using Easy.Tools.GoogleCalendarEvents.Models;
using Easy.Tools.GoogleCalendarEvents.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Easy.Tools.GoogleCalendarEvents.Holidays.Turkiye.Service
{
    public class HolidayService
    {

        private readonly string _apiKey;
        private readonly HttpClient _httpClient;

        public HolidayService(string apiKey)
        {
            _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
        }
        public async Task<IReadOnlyList<Item>> GetHolidaysAsync(CalendarLanguage language = CalendarLanguage.Turkish, CancellationToken cancellationToken = default)
        {
            if (!CalendarMappings.CalendarIds.TryGetValue(language, out var calendarId))
                throw new ArgumentException($"Unsupported language '{language}'");

            var eventService = new GoogleEventService(_apiKey, calendarId);
            return await eventService.GetEventsAsync(cancellationToken);
        }
    }
}
