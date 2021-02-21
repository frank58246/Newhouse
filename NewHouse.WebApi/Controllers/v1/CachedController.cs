using Microsoft.AspNetCore.Mvc;
using NewHouse.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewHouse.WebApi.Controllers.v1
{
    [ApiController]
    [Route("[controller]")]
    public class CachedController : Controller
    {
        [HttpDelete]
        [Route("api/delete")]
        public async Task<IActionResult> Delete(int sid)
        {
            if (sid <= 0)
            {
                var errorResult = new Result()
                {
                    Success = false,
                    Message = "sid必須大於0"
                };
                return BadRequest(errorResult);
            }

            // TODO 串接真實邏輯
            var successResult = new Result()
            {
                Success = true,
                AffectRow = 1
            };

            return Ok(successResult);
        }

        [HttpDelete]
        [Route("api/delete/all")]
        public async Task<IActionResult> DeleteAll()
        {
            // TODO 串接真實邏輯
            var successResult = new Result()
            {
                Success = true
            };

            return Ok(successResult);
        }
    }
}