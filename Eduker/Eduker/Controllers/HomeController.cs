using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Eduker.Models;
using Eduker.ViewModels.CourseVM;
using Eduker.ViewModels.HomeVm;
using Eduker.ViewModels.InstructorsVm;
using Microsoft.AspNetCore.Identity;
using Services.Abstraction;

namespace Eduker.Controllers;

[Route("/")]
public class HomeController : Controller
{
    private readonly IServiceManager _serviceManager;

    public HomeController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }
    public async Task<IActionResult> Index()
    {
        try
        {
            var instructorsList = await _serviceManager.InstructorService.GetAllAsync();
            var commentsList = await _serviceManager.CommentsService.GetAllAsync();
            var coursesList = await _serviceManager.CourseService.GetAllAsync();
            var eventsList = await _serviceManager.EventsService.GetAllAsync();

            var model = new HomeVm()
            {
                Instructors = instructorsList.ToList(),
                Comments = commentsList.ToList(),
                Courses = coursesList.ToList(),
                Events = eventsList.ToList()
            };
            return View(model);
        }
        catch (Exception error)
        {
            return NotFound();
        }
    }
}