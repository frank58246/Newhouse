using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewHouse.Common.Model;
using NewHouse.Service.Dtos;
using NewHouse.Service.Interface;
using NewHouse.WebApi.Models.Input;
using NewHouse.WebApi.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewHouse.WebApi.Controllers.v1
{
    [ApiController]
    [Route("[controller]")]
    public class NewhouseController : Controller
    {
        private readonly INewhouseService _newhouseService;

        private readonly IMapper _mapper;

        public NewhouseController(IMapper mapper,
            INewhouseService newhouseService)
        {
            this._mapper = mapper;
            this._newhouseService = newhouseService;
        }

        [HttpGet]
        public async Task<NewhouseViewModel> Get(int sid)
        {
            var newhouseDto = await this._newhouseService.GetAsync(sid);
            return this._mapper.Map<NewhouseViewModel>(newhouseDto);
        }

        [HttpGet]
        [Route("api/search")]
        public async Task<IActionResult> Search([FromQuery] NewhouseSearchParameter parameter)
        {
            var paremeterDto = this._mapper.Map<NewhouseSearchParameterDto>(parameter);

            await this._newhouseService.SearchAsync(paremeterDto);

            return Ok();
        }
    }
}