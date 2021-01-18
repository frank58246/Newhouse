using AngleSharp;
using AngleSharp.Dom;
using NewHouse.Common.Extension;
using NewHouse.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selector = NewHouse.Common.Constants.ProjectConstants.HtmlSelector.NewHouse;

namespace NewHouse.Repository.Converters
{
    public class NewhouseConverter : INewhouseConverter
    {
        public async Task<Newhouse591Model> ConvertTo591ModelAsync(string htmlString, int hid)
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

            var model = new Newhouse591Model
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

        public async Task<NewhouseModel> ConvertToModelAsync(Newhouse591Model newhouse591Model)
        {
            if (newhouse591Model is null)
            {
                throw new ArgumentNullException();
            }

            var newhouseModel = new NewhouseModel
            {
                BuildName = newhouse591Model.BuildName,
                HighPinPrice = 0,
                HighPrice = 1,
            };

            return newhouseModel;
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