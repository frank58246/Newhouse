using NewHouse.Common.Extension;
using NewHouse.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewHouse.Service.Interface
{
    public class NewhouseConverter : INewhouseConverter
    {
        private readonly ICountyDistrictService _countyDistrictService;

        public NewhouseConverter(ICountyDistrictService countyDistrictService)
        {
            this._countyDistrictService = countyDistrictService;
        }

        public async Task<NewhouseDto> CovertAsync(Newhouse591Dto newhouse591Dto)
        {
            if (newhouse591Dto is null)
            {
                throw new ArgumentNullException(nameof(newhouse591Dto));
            }

            var newhouseDto = new NewhouseDto()

            {
                Hid = newhouse591Dto.Hid,
                BuildName = newhouse591Dto.BuildName,
                HighPinPrice = newhouse591Dto.PinPrice.ToDoubleList().MaxOrDefault(),
                LowPinPrice = newhouse591Dto.PinPrice.ToDoubleList().MinOrDefault(),
                HighPrice = newhouse591Dto.Price.ToIntList().MaxOrDefault(),
                LowPrice = newhouse591Dto.PinPrice.ToIntList().MinOrDefault(),

                County = await this._countyDistrictService.GetCountyName(newhouse591Dto.Address),
                District = await this._countyDistrictService.GetDistrictName(newhouse591Dto.Address)
            };

            return newhouseDto;
        }
    }
}