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
    public DbSet<TimeTracking.Models.TimeSheet> TimeSheet { get; set; }
    public DbSet<TimeTracking.Models.TimeSheetRow> TimeSheetRow { get; set; }
}

