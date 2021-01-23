using AutoMapper;
using NewHouse.Service.Dtos;
using NewHouse.WebApi.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewHouse.WebApi.Mapping
{
    public class WebApiProfile : Profile
    {
        public WebApiProfile()
        {
            this.CreateMap<NewhouseViewModel, NewhouseDto>();
        }
    }
}