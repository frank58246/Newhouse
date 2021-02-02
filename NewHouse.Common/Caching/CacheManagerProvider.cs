using System;
using System.Collections.Generic;
using System.Text;

namespace NewHouse.Common.Caching
{
    public class CacheManagerProvider : ICacheManagerProvider
    {
        private readonly ICacheManager _memoryCacheManager;

        private readonly ICacheManager _distributeCacheManger;

        public CacheManagerProvider(ICacheManager memoryCacheManager,
            ICacheManager distributeCacheManger)
        {
            this._memoryCacheManager = memoryCacheManager;

            this._distributeCacheManger = distributeCacheManger;
        }

        public ICacheManager GetDistrubuteCacheManager()
        {
            return this._distributeCacheManger;
        }

        public ICacheManager GetMemoryCacheManager()
        {
            return this._memoryCacheManager;
        }
    }
}