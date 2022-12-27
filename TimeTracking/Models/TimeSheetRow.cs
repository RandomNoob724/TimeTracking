using System.ComponentModel.DataAnnotations;

namespace TimeTracking.Models
{
    public class TimeSheetRow
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}
