using Microsoft.AspNetCore.Mvc;
using ReportCrimes.Web.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportCrimes.Web.Controllers
{
    public class CrimeController : Controller
    {
        private readonly ICrimeService _crimeService;
        public CrimeController(ICrimeService productService)
        {
            _crimeService = productService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
