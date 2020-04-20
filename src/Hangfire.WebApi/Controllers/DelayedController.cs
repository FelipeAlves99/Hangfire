using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hangfire.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DelayedController : ControllerBase
    {

        // POST: api/Delayed
        [HttpPost]
        public IActionResult Post([FromBody] double value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            BackgroundJob.Schedule(() => null, TimeSpan.FromSeconds(value));

            return Created("CREATED DATA", null);
        }

        // PUT: api/Delayed/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] double value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            BackgroundJob.Schedule(() => null, TimeSpan.FromSeconds(value));

            return Created("CREATED DATA", null);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(double value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            BackgroundJob.Schedule(() => null, TimeSpan.FromSeconds(value));

            return Created("CREATED DATA", null);
        }
    }
}
