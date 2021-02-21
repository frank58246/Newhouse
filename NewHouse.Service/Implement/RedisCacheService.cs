using NewHouse.Common.Caching;
using NewHouse.Common.Constants;
using NewHouse.Common.Model;
using NewHouse.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewHouse.Service.Implement
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly ICacheManager _cacheManager;

        public RedisCacheService(ICacheManagerProvider cacheManagerProvider)
        {
            this._cacheManager = cacheManagerProvider.GetDistrubuteCacheManager();
        }

        public IResult DeleteNewhouseCache(int sid)
        {
            var key = $"{ProjectConstants.Caching.KeyPrefix.NewHouse}{sid}";

            var deleteSuccess = this._cacheManager.Delete(key);

            var result = new Result
            {
                Success = deleteSuccess,
                AffectRow = deleteSuccess ? 1 : 0
            };

            return result;
        }
    }
}