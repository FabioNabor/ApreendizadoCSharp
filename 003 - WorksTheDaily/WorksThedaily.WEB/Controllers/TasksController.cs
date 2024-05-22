using Microsoft.AspNetCore.Mvc;
using WorksThedaily.WEB.Service;

namespace WorksThedaily.WEB.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITaskServices _services;

        public TasksController(ITaskServices services)
        {
            _services = services;
        }

        public async Task<IActionResult> Works()
        {
            var response = await _services.GetTasks();
            return View(response);
        }
    }
}
