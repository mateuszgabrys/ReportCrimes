using LawEnforcementAPI.Models.Dto;
using LawEnforcementAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawEnforcementAPI.Controllers
{
    [Route("api/[controller]")]
    public class LawEnforcementController : Controller
    {
        protected ResponseDto _response;
        private ILawEnforcementRepository _lawEnforcementRepository;
        public LawEnforcementController(ILawEnforcementRepository lawEnforcementRepository)
        {
            _lawEnforcementRepository = lawEnforcementRepository;
            this._response = new ResponseDto();
        }
        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<LawEnforcementDto> lawEnforcements = await _lawEnforcementRepository.GetAll();
                _response.Result = lawEnforcements;
            }
            catch (Exception ex)
            {

                _response.IsSucces = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                LawEnforcementDto lawEnforcements = await _lawEnforcementRepository.GetSingle(id);
                _response.Result = lawEnforcements;
            }
            catch (Exception ex)
            {

                _response.IsSucces = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost]
        public async Task<object> Post([FromBody] LawEnforcementDto lawEnforcement)
        {
            try
            {
                LawEnforcementDto model = await _lawEnforcementRepository.CreateUpdate(lawEnforcement);
                _response.Result = model;
            }
            catch (Exception ex)
            {

                _response.IsSucces = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPut]
        public async Task<object> Put([FromBody] LawEnforcementDto lawEnforcement)
        {
            try
            {
                LawEnforcementDto model = await _lawEnforcementRepository.CreateUpdate(lawEnforcement);
                _response.Result = model;
            }
            catch (Exception ex)
            {

                _response.IsSucces = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool isSucces = await _lawEnforcementRepository.Delete(id);
                _response.Result = isSucces;
            }
            catch (Exception ex)
            {

                _response.IsSucces = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
            }
            return _response;
        }

    }
}
