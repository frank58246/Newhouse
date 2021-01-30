using Dapper;
using NewHouse.Common.Helper;
using NewHouse.Repository.Interface;
using NewHouse.Repository.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewHouse.Repository.Implement
{
    public class DistirctRepository : IDistirctRepository
    {
        private readonly IConnectionHelper _connectionHelper;

        public DistirctRepository(IConnectionHelper connectionHelper)
        {
            this._connectionHelper = connectionHelper;
        }

        public async Task<IEnumerable<DistrictModel>> GetAllAsync()
        {
            var sql = @"
                SELECT [DistrictName],
                       [CountyName],
                       [CountySID]
                FROM [District] WITH(NOLOCK)";

            using (var conn = this._connectionHelper.Common)
            {
                return await conn.QueryAsync<DistrictModel>(sql);
            }
        }
    }
}