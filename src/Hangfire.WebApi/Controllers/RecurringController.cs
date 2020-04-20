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
    public class RecurringController : ControllerBase
    {        
        // POST: api/Recurring
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            string jobID = "1";
            RecurringJob.AddOrUpdate(jobID, () => null, Cron.Minutely);

            return Created("CREATED DATA", null);
        }

        // PUT: api/Recurring/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            string jobID = "1";
            RecurringJob.AddOrUpdate(jobID, () => null, Cron.Minutely);

            return Created("CREATED DATA", null);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            string jobID = "1";
            RecurringJob.RemoveIfExists(jobID);

            return Created("CREATED DATA", null);
        }        
    }
}
