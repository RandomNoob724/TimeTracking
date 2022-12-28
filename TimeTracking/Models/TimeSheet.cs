using System.ComponentModel.DataAnnotations;
using System.Globalization;
using TimeTracking.Utils;

namespace TimeTracking.Models
{
    public class TimeSheet
    {
        public TimeSheet()
        {
            WeekNumber = ISOWeek.GetWeekOfYear(DateTime.Today).ToString();
            TimeSheetRows = new List<TimeSheetRow>();
            StartDate = DateHelper.FirstDayOfWeek(DateTime.Today);
            EndDate = DateHelper.LastDayOfWeek(DateTime.Today);
        }

        [Key]
        public Guid Id { get; set; }
        [Required]
        public string WeekNumber { get; set; } = ISOWeek.GetWeekOfYear(DateTime.Today).ToString();
        public string? Notes { get; set; }
        public List<TimeSheetRow> TimeSheetRows { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
