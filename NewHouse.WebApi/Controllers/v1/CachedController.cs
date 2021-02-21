using Microsoft.AspNetCore.Mvc;
using NewHouse.Common.Model;
using NewHouse.Service.Interface;
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
        private readonly IRedisCacheService _redisCacheService;

        public CachedController(IRedisCacheService redisCacheService)
        {
            this._redisCacheService = redisCacheService;
        }

        [HttpDelete]
        [Route("api/delete")]
        public IActionResult Delete(int sid)
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

            var deleteResult = this._redisCacheService.DeleteNewhouseCache(sid);

            var successResult = new Result()
            {
                Success = deleteResult.Success,
                AffectRow = deleteResult.Success ? 1 : 0
            };

            return Ok(successResult);
        }
    }
}