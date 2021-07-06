using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReportCrimes.Web.Models;
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
        private readonly ILawEnforcementService _lawEnforcementService;
        public CrimeController(ICrimeService productService, ILawEnforcementService lawEnforcementService)
        {
            _crimeService = productService;
            _lawEnforcementService = lawEnforcementService;
        }
        public async Task<IActionResult> CrimeIndex()
        {
            List<CrimeEventDto> list = new();
            var response = await _crimeService.GetAll<ResponseDto>();
            if (response != null && response.IsSucces)
            {
                list = JsonConvert.DeserializeObject<List<CrimeEventDto>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
    }
}
