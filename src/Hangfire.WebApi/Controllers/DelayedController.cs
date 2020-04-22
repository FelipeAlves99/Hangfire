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
        public IActionResult Post()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            double value = 15;
            BackgroundJob.Schedule(() => MethodCalling(), TimeSpan.FromSeconds(value));

            return Created("CREATED DATA", null);
        }

        // PUT: api/Delayed/5
        [HttpPut]
        public IActionResult Put()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            double value = 15;
            BackgroundJob.Schedule(() => MethodCalling(), TimeSpan.FromSeconds(value));

            return Created("CREATED DATA", null);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public IActionResult Delete()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            double value = 15;
            BackgroundJob.Schedule(() => MethodCalling(), TimeSpan.FromSeconds(value));

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
