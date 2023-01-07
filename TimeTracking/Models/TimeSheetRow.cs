using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TimeTracking.Utils;

namespace TimeTracking.Models
{
    public class TimeSheetRow
    {
        public TimeSheetRow(string title)
        {
            Title = title;
            HoursPerday = new Dictionary<DayOfWeek, TimeSpan>()
            {
                { DayOfWeek.Monday, TimeSpan.FromDays(0) },
                { DayOfWeek.Tuesday, TimeSpan.FromDays(0) },
                { DayOfWeek.Wednesday, TimeSpan.FromDays(0) },
                { DayOfWeek.Thursday, TimeSpan.FromDays(0) },
                { DayOfWeek.Friday, TimeSpan.FromDays(0) },
                { DayOfWeek.Saturday, TimeSpan.FromDays(0) },
                { DayOfWeek.Sunday, TimeSpan.FromDays(0) }
            };
        }

        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        [Column(TypeName = "json")]
        public Dictionary<DayOfWeek, TimeSpan> HoursPerday { get; set; }
    }
}
