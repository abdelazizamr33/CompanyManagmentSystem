using System.Diagnostics;
using System.Text;
using Company.Route.PL.Models;
using Company.Route.PL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Company.Route.PL.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IScopedService _scopedService1;
        private readonly IScopedService _scopedService2;
        private readonly ITransientService _transientService1;
        private readonly ITransientService _transientService2;
        private readonly ISingeltonService _singeltonService1;
        private readonly ISingeltonService _singeltonService2;

        public HomeController(ILogger<HomeController> logger
            ,IScopedService scopedService1
            , IScopedService scopedService2
            , ITransientService transientService1
            , ITransientService transientService2
            , ISingeltonService singeltonService1
            , ISingeltonService singeltonService2)
        {
            _logger = logger;
           _scopedService1 = scopedService1;
           _scopedService2 = scopedService2;
           _transientService1 = transientService1;
           _transientService2 = transientService2;
           _singeltonService1 = singeltonService1;
           _singeltonService2 = singeltonService2;
        }

        public string TestLifeTime()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"scopedService1 :: {_scopedService1.GetGuid()}\n");
            builder.Append($"scopedService2 :: {_scopedService2.GetGuid()}\n\n");
            builder.Append($"transientService1 :: {_transientService1.GetGuid()}\n");
            builder.Append($"transientService2 :: {_transientService2.GetGuid()}\n\n");
            builder.Append($"singeltonService1 :: {_scopedService1.GetGuid()}\n");
            builder.Append($"singeltonService :: {_scopedService2.GetGuid()}\n\n");
            return builder.ToString();
        }
        public IActionResult Index()
        {
            return View();
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
}
