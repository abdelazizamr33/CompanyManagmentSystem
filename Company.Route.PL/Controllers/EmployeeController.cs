using Microsoft.AspNetCore.Mvc;

namespace Company.Route.PL.Controllers
{
    public class EmployeeController : Controller
    {
        public EmployeeController():base()
        {
            
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
