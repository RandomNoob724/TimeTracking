using TimeTracking.Models;

namespace TimeTracking.ViewModels
{
    public class TimeSheetRowViewModel
    {
        public TimeSheetRow TimeSheetRow { get; set; }
        public List<Project> Projects { get; set; }
    }
}
