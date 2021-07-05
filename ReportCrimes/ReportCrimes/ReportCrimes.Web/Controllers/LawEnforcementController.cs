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
    public class LawEnforcementController : Controller
    {
        private readonly ILawEnforcementService _lawEnforcementService;
        public LawEnforcementController(ILawEnforcementService lawEnforcementService)
        {
            _lawEnforcementService = lawEnforcementService;
        }
        public async Task<IActionResult> LawEnforcementIndex()
        {
            List<LawEnforcementDto> list = new();
            var response = await _lawEnforcementService.GetAll<ResponseDto>();
            if(response!=null && response.IsSucces)
            {
                list = JsonConvert.DeserializeObject<List<LawEnforcementDto>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
    }
}
