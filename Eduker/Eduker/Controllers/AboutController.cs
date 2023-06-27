using Eduker.ViewModels.InstructorsVm;
using Microsoft.AspNetCore.Mvc;
using Services.Abstraction;

namespace Eduker.Controllers;

[Route("/about")]
public class AboutController : Controller
{
    private readonly IServiceManager _serviceManager;

    public AboutController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }
    public async Task<IActionResult> Index()
    {
        try
        {
            var instructorsList = await _serviceManager.InstructorService.GetAllAsync();

            var model = new InstructorsVm()
            {
                Instructors = instructorsList.ToList(),
            };
            return View(model);
        }
        catch (Exception error)
        {
            return NotFound();
        }
    }
}