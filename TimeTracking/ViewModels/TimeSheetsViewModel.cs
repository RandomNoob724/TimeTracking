using TimeTracking.Models;

namespace TimeTracking.ViewModels
{
    public class TimeSheetsViewModel
    {
        public TimeSheet TimeSheet { get; set; }
        public List<Project> Projects { get; set; }
    }
}
