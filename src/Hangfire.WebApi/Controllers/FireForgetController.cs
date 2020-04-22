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
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("working fine");
        }

        // POST: api/FireForget
        [HttpPost]
        public IActionResult Post()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            BackgroundJob.Enqueue(() => MethodCalling());

            return Created("CREATED DATA", null);
        }

        // PUT: api/FireForget/5
        [HttpPut]
        public IActionResult Put()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            BackgroundJob.Enqueue(() => MethodCalling());

            return Ok("UPDATED DATA");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public IActionResult Delete()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            BackgroundJob.Enqueue(() => MethodCalling());

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
