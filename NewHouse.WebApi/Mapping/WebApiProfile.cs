using AutoMapper;
using NewHouse.Common.Enums;
using NewHouse.Common.Model;
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
            this.CreateMap<NewhouseDto, NewhouseViewModel>();

            this.CreateMap<NewhouseSearchParameter, NewhouseSearchParameterDto>();
        }
    }
}