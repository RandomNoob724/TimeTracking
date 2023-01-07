using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TimeTracking.Models;
using TimeTracking.Data;
using TimeTracking.ViewModels;

namespace TimeTracking.Controllers;

public class HomeController : BaseController
{
    public HomeController(ApplicationDbContext context): base(context)
    {

    }

    public async Task<IActionResult> Index()
    {
        TimeSheet activeTimeSheet = await GetActiveTimeSheet();
        if(activeTimeSheet == null)
        {
            TimeSheet thisWeeksTimeSheet = new TimeSheet();
            _context.TimeSheet.Add(thisWeeksTimeSheet);
            await _context.SaveChangesAsync();
            return View(new HomeViewModel() { ActiveTimeSheet = thisWeeksTimeSheet });
        }
        HomeViewModel homeViewModel = new HomeViewModel()
        {
            ActiveTimeSheet = activeTimeSheet
        };
        return View(homeViewModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

