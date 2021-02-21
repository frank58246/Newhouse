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

        public Task<IResult> DeleteNewhouseCache(int hid)
        {
            var key = ProjectConstants.Caching.NewHouse.CacheKey(hid);
            throw new NotImplementedException();
        }
    }
}