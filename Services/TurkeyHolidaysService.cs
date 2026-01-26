using Easy.Tools.GoogleCalendarEvents.Holidays.Turkiye.Enums;
using Easy.Tools.GoogleCalendarEvents.Models;
using Easy.Tools.GoogleCalendarEvents.Services;
using System.Net.Http;

namespace Easy.Tools.GoogleCalendarEvents.Holidays.Turkiye.Services
{
    /// <summary>
    /// Provides functionality to fetch official holidays for Turkey from Google Calendar.
    /// </summary>
    public class TurkeyHolidaysService
    {
        private readonly string _apiKey;
        private readonly HttpClient _httpClient;

        private const string CalendarIdTr = "tr.turkish#holiday@group.v.calendar.google.com";
        private const string CalendarIdEn = "en.turkish.official#holiday@group.v.calendar.google.com";

        /// <summary>
        /// Initializes a new instance of the <see cref="TurkeyHolidaysService"/> class.
        /// </summary>
        /// <param name="apiKey">Your Google Cloud Console API Key.</param>
        /// <param name="httpClient">Optional HttpClient for Dependency Injection.</param>
        public TurkeyHolidaysService(string apiKey, HttpClient? httpClient = null)
        {
            _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
            _httpClient = httpClient ?? new HttpClient();
        }

        /// <summary>
        /// Fetches the list of holidays asynchronously.
        /// </summary>
        /// <param name="language">Language of the holiday names (Turkish or English).</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>List of holiday items.</returns>
        public async Task<IReadOnlyList<Item>> GetHolidaysAsync(HolidayLanguage language = HolidayLanguage.Turkish, CancellationToken cancellationToken = default)
        {
            var calendarId = language switch
            {
                HolidayLanguage.English => CalendarIdEn,
                _ => CalendarIdTr // Default Turkish
            };

            var eventService = new GoogleEventService(_apiKey, calendarId, _httpClient);

            return await eventService.GetEventsAsync(cancellationToken);
        }
    }
}