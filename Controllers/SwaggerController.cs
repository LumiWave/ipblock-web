using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using devLap.Models;

namespace devLap.Controllers
{
    public class SwaggerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
