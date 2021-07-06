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
        private readonly ICrimeService _crimeService;
        public LawEnforcementController(ICrimeService crimeService, ILawEnforcementService lawEnforcementService)
        {
            _lawEnforcementService = lawEnforcementService;
            _crimeService = crimeService;

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

        public async Task<IActionResult> LawEnforcementCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LawEnforcementCreate(LawEnforcementDto law)
        {
            if (ModelState.IsValid)
            {
                var response = await _lawEnforcementService.Create<ResponseDto>(law);
                if (response != null && response.IsSucces)
                {
                    return RedirectToAction(nameof(LawEnforcementIndex));
                }
            }
            return View(law);
        }

        public async Task<IActionResult> LawEnforcementEdit(int id)
        {
            List<CrimeEventDto> list = new();
            var response = await _crimeService.GetAll<ResponseDto>();
            if (response != null && response.IsSucces)
            {
                list = JsonConvert.DeserializeObject<List<CrimeEventDto>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
        //[HttpPost]
        //public async Task<IActionResult> LawEnforcementEdit(LawEnforcementDto law)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var response = await _lawEnforcementService.Update<ResponseDto>(law);
                
        //        if (response != null && response.IsSucces)
        //        {
        //            return RedirectToAction(nameof(LawEnforcementIndex));
        //        }
        //    }
        //    return View(law);
        //}

        public async Task<IActionResult> LawEnforcementDelete(int id)
        {
            var response = await _lawEnforcementService.GetSingle<ResponseDto>(id);
            if (response != null && response.IsSucces)
            {
                LawEnforcementDto model = JsonConvert.DeserializeObject<LawEnforcementDto>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> LawEnforcementDelete(LawEnforcementDto law)
        {
            if (ModelState.IsValid)
            {
                var cos = law;
                var response = await _lawEnforcementService.Delete<ResponseDto>(law.LawEnforcementId);

                if (response.IsSucces)
                {
                    return RedirectToAction(nameof(LawEnforcementIndex));
                }
            }
            return View(law);
        }
    }
}
