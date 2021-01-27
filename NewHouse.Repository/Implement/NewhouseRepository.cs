using Dapper;
using NewHouse.Common.Helper;
using NewHouse.Common.Model;
using NewHouse.Repository.Interface;
using NewHouse.Repository.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewHouse.Repository.Implement
{
    public class NewhouseRepository : INewhouseRepository
    {
        private readonly IConnectionHelper _connectionHelper;

        public NewhouseRepository(IConnectionHelper connectionHelper)
        {
            this._connectionHelper = connectionHelper;
        }

        public async Task<NewhouseModel> GetAsync(int hid)
        {
            var sql = @"
                SELECT *
                FROM Newhouse WITH(NOLOCK)
                WHERE HID = @HID";

            var parameter = new { HID = hid };
            using (var conn = this._connectionHelper.House)
            {
                return await conn.QueryFirstOrDefaultAsync<NewhouseModel>(sql, parameter);
            }
        }

        public async Task<IResult> InsertAsync(NewhouseModel newhouseModel)
        {
            var sql = @"
                INSERT INTO [dbo].[Newhouse]
                       ([HID]
                       ,[BuildName]
                       ,[Info]
                       ,[HighPinPrice]
                       ,[LowPinPrice]
                       ,[HighPrice]
                       ,[LowPrice]
                       ,[County]
                       ,[District]
                       ,[CreateTime]
                       ,[UpdateTime])
                 VALUES
                       (@HID
                       ,@BuildName
                       ,@Info
                       ,@HighPinPrice
                       ,@LowPinPrice
                       ,@HighPrice
                       ,@LowPrice
                       ,@County
                       ,@District
                       ,@CreateTime
                       ,@UpdateTime)";

            using (var conn = this._connectionHelper.House)
            {
                var result = await conn.ExecuteAsync(sql, newhouseModel);

                return new Result()
                {
                    AffectRow = 1,
                    Message = "",
                    Success = true
                };
            }
        }
    }
}