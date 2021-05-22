using AutoMapper;
using NewHouse.Repository.Model;
using NewHouse.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace NewHouse.Service.Mapping
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            this.CreateMap<Newhouse591Dto, Newhouse591Model>()
                .ReverseMap();

            this.CreateMap<NewhouseModel, NewhouseDto>()
                .ReverseMap();

            this.CreateMap<DistrictModel, DistrictDto>();

            this.CreateMap<NewhouseDto, NewhouseESModel>();

            this.CreateMap<NewhouseSearchParameterDto, NewhouseSearchParameterModel>();

            this.CreateMap<NewhouseSimpleDto, NewhouseESModel>();
        }
    }
}