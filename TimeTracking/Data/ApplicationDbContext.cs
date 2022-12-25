using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TimeTracking.Models;

namespace TimeTracking.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<TimeTracking.Models.Customer> Customer { get; set; }
    public DbSet<TimeTracking.Models.Project> Project { get; set; }
}

