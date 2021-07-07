using LawEnforcementAPI.Models.Dto;
using LawEnforcementAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LawEnforcementAPI.Controllers
{
    [Route("api/[controller]")]
    public class LawEnforcementController : Controller
    {
        protected ResponseDto _response;
        private readonly ILogger<LawEnforcementController> _logger;
        private ILawEnforcementRepository _lawEnforcementRepository;
        public LawEnforcementController(ILogger<LawEnforcementController> logger, ILawEnforcementRepository lawEnforcementRepository)
        {
            _logger = logger;
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
                _logger.LogInformation("success");
            }
            catch (Exception ex)
            {

                _response.IsSucces = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
                _logger.LogWarning("not success");
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
                _logger.LogInformation("OK");
            }
            catch (Exception ex)
            {

                _response.IsSucces = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
                _logger.LogWarning("not success");
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
                _logger.LogInformation("OK");
            }
            catch (Exception ex)
            {

                _response.IsSucces = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
                _logger.LogWarning("not success");
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
                _logger.LogInformation("OK");
            }
            catch (Exception ex)
            {

                _response.IsSucces = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
                _logger.LogWarning("not success");
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
                _logger.LogInformation("OK");
            }
            catch (Exception ex)
            {

                _response.IsSucces = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
                _logger.LogWarning("not success");
            }
            return _response;
        }

    }
}
