using TimeTracking.Models;

namespace TimeTracking.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel()
        {

        }
        public List<TimeSheet> timeSheets { get; set; }
    }
}
