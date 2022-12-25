using System.ComponentModel.DataAnnotations;

namespace TimeTracking.Models
{
    public class Customer
    {
        public Customer()
        {
            Name = string.Empty;
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
