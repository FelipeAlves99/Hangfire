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
        // POST: api/Recurring/trigger
        [HttpGet("trigger")]
        public IActionResult GetTrigger()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            string jobID = "2";
            RecurringJob.Trigger(jobID);

            return Ok("Triggered job " + jobID);
        }

        // POST: api/Recurring
        [HttpPost]
        public IActionResult Post()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            string jobID = "2";
            RecurringJob.AddOrUpdate(jobID, () => MethodCalling(), Cron.Hourly);

            return Created("CREATED DATA", null);
        }

        // PUT: api/Recurring/5
        [HttpPut]
        public IActionResult Put()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            string jobID = "1";
            RecurringJob.AddOrUpdate(jobID, () => MethodCalling(), Cron.Minutely);

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete()]
        public IActionResult Delete()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            string jobID = "1";
            RecurringJob.RemoveIfExists(jobID);

            return Delete();
        }
       
        public void MethodCalling()
        {
            //do something
            for (int i = 0; i < 1000; i++)
            {
                i++;
            }
        }
    }
}
