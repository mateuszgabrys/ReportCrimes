using CrimeEventAPI.Models;
using CrimeEventAPI.Models.Dto;
using CrimeEventAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrimeEventAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrimeController : Controller
    {
        private readonly ICrimeService _service;
        protected ResponseDto _response;
        public CrimeController(ICrimeService service)
        {
            _service = service;
            this._response = new ResponseDto();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CrimeEvent>>> GetAll()
        {
            var entries = await _service.GetAll();
            return Ok(entries);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<CrimeEvent>>> GetEntry([FromRoute] string id)
        {
            var entry = await _service.Get(id);
            return Ok(entry);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await _service.Delete(id);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CrimeEvent dto)
        {
            var newEntry = await _service.Add(dto);
            return Ok(newEntry);
        }

    }
}
