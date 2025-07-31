using Easy.Tools.GoogleCalendarEvents.Holidays.Turkiye.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Tools.GoogleCalendarEvents.Holidays.Turkiye.Value
{
    public static class CalendarMappings
    {
        public static readonly Dictionary<CalendarLanguage, string> CalendarIds = new()
    {
        { CalendarLanguage.Turkish, "tr.turkish#holiday@group.v.calendar.google.com" },
        { CalendarLanguage.English, "en.turkish.official#holiday@group.v.calendar.google.com" }
    };
    }
}
