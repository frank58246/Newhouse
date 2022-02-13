using AngleSharp;
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
using System.Net;
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

        public async Task<string> FetchDetailHtmlAsync(int hid)
        {
            var baseUrl = this._websiteUrlHelper.NewHouse591;
            var url = baseUrl.AppendPathSegment("/home/housing/detail")

                             .SetQueryParam("hid", hid);

            var response = await this._httpClient.GetAsync(url);

            return await response.ContentStringAsync();
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
                                       ,[PinPrice]
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
                                       ,@PinPrice
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

        public async Task<IEnumerable<Newhouse591Model>> GetAllAsync()
        {
            var sql = @"
                      SELECT  [SID]
                              ,[HID]
                              ,[BuildName]
                              ,[Address]
                              ,[CreateTime]
                              ,[UpdateTime]
                              ,[Info]
                              ,[Price]
                              ,[ParkingPrice]
                              ,[PublicSale]
                              ,[HouseDeliveries]
                              ,[HousePlan]
                              ,[PinPrice]
                              ,[CaseType]
                              ,[ReceptionAddress]
                              ,[InvestCompany]
                              ,[ConstructionCompany]
                      FROM Newhouse591";

            using (var conn = this._connectionHelper.House)
            {
                return await conn.QueryAsync<Newhouse591Model>(sql);
            }
        }
    }
}