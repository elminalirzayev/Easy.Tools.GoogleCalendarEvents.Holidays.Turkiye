using Easy.Tools.GoogleCalendarEvents.Models;
using Easy.Tools.GoogleCalendarEvents.Holidays.Turkiye.Services;
using Easy.Tools.GoogleCalendarEvents.Holidays.Turkiye.Enums;
using Easy.Tools.GoogleCalendarEvents.Holidays.Turkiye.Enum;
using System.Net.Http;

namespace Easy.Tools.GoogleCalendarEvents.Holidays.Turkiye.Service
{

    [Obsolete("This class is deprecated. Please use 'TurkeyHolidaysService' instead.")]
    public class HolidayService
    {
        private readonly TurkeyHolidaysService _newService;

        public HolidayService(string apiKey, HttpClient? httpClient = null)
        {
            _newService = new TurkeyHolidaysService(apiKey, httpClient);
        }

        public async Task<IReadOnlyList<Item>> GetHolidaysAsync(CalendarLanguage language = CalendarLanguage.Turkish, CancellationToken cancellationToken = default)
        {
            var newLang = language == CalendarLanguage.English ? HolidayLanguage.English : HolidayLanguage.Turkish;

            return await _newService.GetHolidaysAsync(newLang, cancellationToken);
        }
    }
}