using AngleSharp;
using AngleSharp.Dom;
using NewHouse.Common.Extension;
using NewHouse.Service.Dtos;
using NewHouse.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selector = NewHouse.Common.Constants.ProjectConstants.HtmlSelector.NewHouse;

namespace NewHouse.Service.Implement
{
    public class NewhouseConverter : INewhouseConverter
    {
        private readonly ICountyDistrictService _countyDistrictService;

        public NewhouseConverter(ICountyDistrictService countyDistrictService)
        {
            this._countyDistrictService = countyDistrictService;
        }

        public async Task<Newhouse591Dto> ConvertTo591DtoAsync(string htmlString, int hid)
        {
            if (htmlString.IsNullOrEmpty())
            {
                return null;
            }

            var config = Configuration.Default;
            var context = BrowsingContext.New(config);

            htmlString = htmlString.Replace("&nbsp;", "")
                                   .Replace("<br />", "\n");

            var document = await context.OpenAsync(res => res.Content(htmlString));

            var model = new Newhouse591Dto
            {
                Hid = hid,
                BuildName = this.GetSingleSelectorValue(document, Selector.BuildName),
                Info = this.GetSingleSelectorValue(document, Selector.Info, needTrim: false),
                PinPrice = this.GetSingleSelectorValue(document, Selector.PinPrice),
                Price = this.GetSingleSelectorValue(document, Selector.Price),
                ParkingPrice = this.GetSingleSelectorValue(document, Selector.ParkingPrice),
                PublicSale = this.GetSingleSelectorValue(document, Selector.PublicSale),
                HouseDeliveries = this.GetSingleSelectorValue(document, Selector.HouseDeliveries),
                HousePlan = this.GetSingleSelectorValue(document, Selector.HousePlan),

                CaseType = this.GetSingleSelectorValue(document, Selector.CaseType),
                Address = this.GetSingleSelectorValue(document, Selector.Address),
                ReceptionAddress = this.GetSingleSelectorValue(document, Selector.ReceptionAddress),
                InvestCompany = this.GetSingleSelectorValue(document, Selector.InvestCompany),
                ConstructionCompany = this.GetSingleSelectorValue(document, Selector.ConstructionCompany),

                UpdateTime = DateTime.Now
            };

            if (model.BuildName.IsNullOrEmpty())
            {
                return null;
            }

            return model;
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
                LowPrice = newhouse591Dto.Price.ToIntList().MinOrDefault(),
                Info = newhouse591Dto.Info,
                County = await this._countyDistrictService.GetCountyName(newhouse591Dto.Address),
                District = await this._countyDistrictService.GetDistrictName(newhouse591Dto.Address)
            };

            return newhouseDto;
        }

        private string GetSingleSelectorValue(IDocument document, string selector, bool needTrim = true)
        {
            var values = document.QuerySelectorAll(selector);
            if (values is null || values.Count() == 0)
            {
                return "";
            }

            return needTrim ? values.FirstOrDefault().TextContent.Trim()
                            : values.FirstOrDefault().TextContent;
        }
    }
}