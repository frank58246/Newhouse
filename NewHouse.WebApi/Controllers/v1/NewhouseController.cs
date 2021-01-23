using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewHouse.WebApi.Controllers.v1
{
    [ApiController]
    [Route("[controller]")]
    public class NewhouseController
    {
        [HttpGet]
        public ActionResult<IActionResult> Get(int sid)
        {
            return null;
        }
    }
}