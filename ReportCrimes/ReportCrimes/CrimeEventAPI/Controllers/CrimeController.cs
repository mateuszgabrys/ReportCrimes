using CrimeEventAPI.Models;
using CrimeEventAPI.Models.Dto;
using CrimeEventAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrimeEventAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrimeController : Controller
    {
        private readonly ILogger<CrimeController> _logger;
        private readonly ICrimeService _service;
        protected ResponseDto _response;
        public CrimeController(ILogger<CrimeController> logger, ICrimeService service)
        {
            _logger = logger;
            _service = service;
            this._response = new ResponseDto();
        }

        [HttpGet]
        public async Task<object> GetAll()
        {
            try
            {
                IEnumerable<CrimeEvent> crimes = await _service.GetAll();
                _response.Result = crimes;
                _logger.LogInformation("succes");
            }
            catch (Exception ex)
            {

                _response.IsSucces = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
                _logger.LogWarning("not succes");
            }
            return _response;

            //var crimes = await _service.GetAll();
            //return Ok(crimes);
        }

        [HttpGet("{id}")]
        public async Task<object> Get([FromRoute] string id)
        {
            try
            {
                CrimeEvent crime = await _service.Get(id);
                _response.Result = crime;
                _logger.LogInformation("succes");
            }
            catch (Exception ex)
            {

                _response.IsSucces = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
                _logger.LogWarning("not succes");
            }
            return _response;
            //var entry = await _service.Get(id);
            //return Ok(entry);
        }

        [HttpDelete("{id}")]
        public async Task<object> Delete(string id)
        {
            try
            {
                bool isSucces = await _service.Delete(id);
                _response.Result = isSucces;
                _logger.LogInformation("succes");
            }
            catch (Exception ex)
            {

                _response.IsSucces = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
                _logger.LogWarning("not succes");
            }
            return _response;
            //await _service.Delete(id);
            //return NoContent();
        }

        [HttpPost]
        public async Task<object> Post([FromBody] CrimeEvent dto)
        {
            try
            {
                CrimeEvent model = await _service.Add(dto);
                _response.Result = model;
                _logger.LogInformation("succes");
            }
            catch (Exception ex)
            {

                _response.IsSucces = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
                _logger.LogWarning("not succes");
            }
            return _response;
            //var newEntry = await _service.Add(dto);
            //return Ok(newEntry);
        }

    }
}
