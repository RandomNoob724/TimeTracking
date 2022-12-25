namespace TimeTracking.Models
{
    public class Project
    {
        public Project()
        {
            Name = String.Empty;
            Customer = new Customer();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Customer Customer { get; set; }
    }
}
