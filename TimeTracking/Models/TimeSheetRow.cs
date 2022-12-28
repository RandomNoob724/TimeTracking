using System.ComponentModel.DataAnnotations;

namespace TimeTracking.Models
{
    public class TimeSheetRow
    {
        public TimeSheetRow(string title)
        {
            Title = title;
        }

        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}
