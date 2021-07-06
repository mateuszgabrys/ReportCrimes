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

        public async Task<IActionResult> Details(string id)
        {
            CrimeEventDto model = new();
            var response = await _crimeService.GetSingle<ResponseDto>(id);
            if (response != null && response.IsSucces)
            {
                model = JsonConvert.DeserializeObject<CrimeEventDto>(Convert.ToString(response.Result));
            }
            return View(model);
        }

        public async Task<IActionResult> CrimeCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CrimeCreate(CrimeEventDto dto)
        {
            //if (ModelState.IsValid)
            //{
            //    var response = await _lawEnforcementService.Create<ResponseDto>(law);
            //    if (response != null && response.IsSucces)
            //    {
            //        return RedirectToAction(nameof(LawEnforcementIndex));
            //    }
            //}
            CrimeEventDto correctModel = new();
            List<CrimeEventDto> crimesList = new();
            List<LawEnforcementDto> list = new();
            var evn = await _crimeService.GetAllEnv<ResponseDto>();
            if (evn != null && evn.IsSucces)
            {
                list = JsonConvert.DeserializeObject<List<LawEnforcementDto>>(Convert.ToString(evn.Result));
            }
            var assaultDepartment = list.Find(x => x.RankOfLawEnforcement == "Assault Department");
            var burglaryDepartment = list.Find(x => x.RankOfLawEnforcement == "Burglary Department");
            var fraudDepartment = list.Find(x => x.RankOfLawEnforcement == "Fraud Department");
            if(dto.TypeOfEvent == "Assault")
            {
                correctModel.CrimeId = dto.CrimeId;
                correctModel.DateOfEvent = DateTime.Now;
                correctModel.Description = dto.Description;
                correctModel.PlaceOfEvent = dto.PlaceOfEvent;
                correctModel.Status = dto.Status;
                correctModel.TypeOfEvent = dto.TypeOfEvent;
                correctModel.ReportingPersonEmail = dto.ReportingPersonEmail;
                correctModel.LawEnforcementId = assaultDepartment.LawEnforcementId;
            }
            else if(dto.TypeOfEvent == "Burglary")
            {
                correctModel.CrimeId = dto.CrimeId;
                correctModel.DateOfEvent = DateTime.Now;
                correctModel.Description = dto.Description;
                correctModel.PlaceOfEvent = dto.PlaceOfEvent;
                correctModel.Status = dto.Status;
                correctModel.TypeOfEvent = dto.TypeOfEvent;
                correctModel.ReportingPersonEmail = dto.ReportingPersonEmail;
                correctModel.LawEnforcementId = burglaryDepartment.LawEnforcementId;
            }
            else
            {
                correctModel.CrimeId = dto.CrimeId;
                correctModel.DateOfEvent = DateTime.Now;
                correctModel.Description = dto.Description;
                correctModel.PlaceOfEvent = dto.PlaceOfEvent;
                correctModel.Status = dto.Status;
                correctModel.TypeOfEvent = dto.TypeOfEvent;
                correctModel.ReportingPersonEmail = dto.ReportingPersonEmail;
                correctModel.LawEnforcementId = fraudDepartment.LawEnforcementId;
            }
            
            var response = await _crimeService.Create<ResponseDto>(correctModel);
            if (response != null && response.IsSucces)
            {
                crimesList.Add(correctModel);
                return RedirectToAction(nameof(CrimeIndex));
            }
            return View(dto);
        }
    }
}
