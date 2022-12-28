using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeTracking.Data;
using TimeTracking.Models;
using TimeTracking.Utils;

namespace TimeTracking.Controllers
{
    public class BaseController : Controller
    {
        //private readonly ILogger<BaseController> _logger;
        //private readonly IHttpContextAccessor _contextAccessor;
        //private readonly IConfiguration _configuration;
        protected readonly ApplicationDbContext _context;
        public BaseController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TimeSheet> GetActiveTimeSheet()
        {
            DateTime firstDayOfWeek = DateHelper.FirstDayOfWeek(DateTime.Today);
            DateTime lastDayOfWeek = DateHelper.LastDayOfWeek(DateTime.Today);
            TimeSheet timesheet = await _context.TimeSheet.Where(timeSheet => 
                timeSheet.StartDate >= firstDayOfWeek && 
                timeSheet.EndDate <= lastDayOfWeek)
                .FirstOrDefaultAsync();
            return timesheet;
        }
    }
}
