using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hangfire.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FireForgetController : ControllerBase
    {
        // POST: api/FireForget
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            BackgroundJob.Enqueue(() => null);

            return Created("CREATED DATA", null);
        }

        // PUT: api/FireForget/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            BackgroundJob.Enqueue(() => null);

            return Ok("UPDATED DATA");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            BackgroundJob.Enqueue(() => null);

            return Delete(1);
        }
    }
}
