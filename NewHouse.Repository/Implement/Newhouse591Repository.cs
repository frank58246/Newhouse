﻿using AngleSharp;
using AngleSharp.Dom;
using Dapper;
using Flurl;
using NewHouse.Common.Constants;
using NewHouse.Common.Extension;
using NewHouse.Common.Helper;
using NewHouse.Common.Model;
using NewHouse.Repository.Interface;
using NewHouse.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Selector = NewHouse.Common.Constants.ProjectConstants.HtmlSelector.NewHouse;

namespace NewHouse.Repository.Implement
{
    public class Newhouse591Repository : APIBaseRepository, INewhouse591Repository
    {
        private readonly IConnectionHelper _connectionHelper;

        public Newhouse591Repository(HttpClient httpClient,
            IWebsiteUrlHelper websiteUrlHelper,
            IConnectionHelper connectionHelper)
            : base(httpClient, websiteUrlHelper)
        {
            this._connectionHelper = connectionHelper;
        }

        public async Task<bool> ExistAsync(int hid)
        {
            var sql = @"
                      SELECT *
                      FROM Newhouse591
                      WHERE Hid = @Hid";

            var parameter = new { Hid = hid };

            using (var conn = this._connectionHelper.House)
            {
                var result = await conn.QueryAsync<Newhouse591Model>(sql, parameter);

                return result != null && result.Count() > 0;
            }
        }

        public async Task<Newhouse591Model> FetchAsync(int hid)
        {
            var baseUrl = this._websiteUrlHelper.NewHouse591;
            var url = baseUrl.AppendPathSegment("/home/housing/info")
                             .SetQueryParam("hid", hid);

            var config = Configuration.Default;
            var context = BrowsingContext.New(config);

            var response = await this._httpClient.GetAsync(url);
            var responseString = await response.ContentStringAsync();

            responseString = responseString.Replace("&nbsp;", "")
                                           .Replace("<br />", "\n");

            var document = await context.OpenAsync(res => res.Content(responseString));

            var model = new Newhouse591Model
            {
                Hid = hid,
                BuildName = this.GetSingleValue(document, Selector.BuildName),
                Info = this.GetSingleValue(document, Selector.Info, needTrim: false),
                PinPrice = this.GetSingleValue(document, Selector.PinPrice),
                Price = this.GetSingleValue(document, Selector.Price),
                ParkingPrice = this.GetSingleValue(document, Selector.ParkingPrice),
                PublicSale = this.GetSingleValue(document, Selector.PublicSale),
                HouseDeliveries = this.GetSingleValue(document, Selector.HouseDeliveries),
                HousePlan = this.GetSingleValue(document, Selector.HousePlan),

                CaseType = this.GetSingleValue(document, Selector.CaseType),
                Address = this.GetSingleValue(document, Selector.Address),
                ReceptionAddress = this.GetSingleValue(document, Selector.ReceptionAddress),
                InvestCompany = this.GetSingleValue(document, Selector.InvestCompany),
                ConstructionCompany = this.GetSingleValue(document, Selector.ConstructionCompany),

                UpdateTime = DateTime.Now
            };

            return model;
        }

        public async Task<IResult> InsertAsync(Newhouse591Model model)
        {
            var sql = @"
                            INSERT INTO [Newhouse591]
                                       ([HID]
                                       ,[BuildName]
                                       ,[Address]
                                       ,[UpdateTime]
                                       ,[Info]
                                       ,[Price]
                                       ,[ParkingPrice]
                                       ,[PublicSale]
                                       ,[HouseDeliveries]
                                       ,[HousePlan])
                                 VALUES
                                       (@HID
                                       ,@BuildName
                                       ,@Address
                                       ,@UpdateTime
                                       ,@Info
                                       ,@Price
                                       ,@ParkingPrice
                                       ,@PublicSale
                                       ,@HouseDeliveries
                                       ,@HousePlan)";
            using (var conn = this._connectionHelper.House)
            {
                var result = await conn.ExecuteAsync(sql, model);

                return new Result()
                {
                    AffectRow = 1,
                    Message = "",
                    Success = true
                };
            }
        }

        private string GetSingleValue(IDocument document, string selector, bool needTrim = true)
        {
            var values = document.QuerySelectorAll(selector);
            if (values is null || values.Count() == 0)
            {
                return "";
            }

            return needTrim ? values.SingleOrDefault().TextContent.Trim()
                            : values.SingleOrDefault().TextContent;
        }
    }
}