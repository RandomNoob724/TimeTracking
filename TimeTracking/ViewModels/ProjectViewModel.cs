using TimeTracking.Models;

namespace TimeTracking.ViewModels
{
    public class ProjectViewModel
    {
        public Project Project { get; set; } = new Project();

        public List<Customer> Customers { get; set; } = new List<Customer>();
    }
}
