using System.Globalization;

namespace TimeTracking.Utils
{
    public static class DateHelper
    {
        public static DateTime FirstDayOfWeek(DateTime date)
        {
            DayOfWeek firstDayOfWeek = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
            int dateOffset = firstDayOfWeek - date.DayOfWeek;
            DateTime firstDayOfWeekDate = date.AddDays(dateOffset);
            return firstDayOfWeekDate;
        }

        public static DateTime LastDayOfWeek(DateTime date)
        {
            DateTime lastDayOfWeekDate = FirstDayOfWeek(date).AddDays(6);
            return lastDayOfWeekDate;
        }
    }
}
