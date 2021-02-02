using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using System.Text;

namespace NewHouse.Common.Caching
{
    public class MemoryCacheManager : ICacheManager
    {
        //加入Lock機制限定同一Key同一時間只有一個Callback執行
        private const string _asyncLockPrefix = "$$MemoryCacheAsyncLock#";

        private readonly IMemoryCache _cache;

        private readonly TimeSpan _defaultCacheTime;

        public MemoryCacheManager(IMemoryCache cache, TimeSpan defaultCacheTime)
        {
            this._cache = cache;
            this._defaultCacheTime = defaultCacheTime;
        }

        public T Get<T>(string key)
        {
            lock (GetAsyncLock(key))
            {
                if (this._cache.Get<T>(key) != null)
                {
                    return this._cache.Get<T>(key);
                }

                return default(T);
            }
        }

        public bool Save<T>(string key, T value)
        {
            return this.Save(key, value, this._defaultCacheTime);
        }

        public bool Save<T>(string key, T value, TimeSpan cacheTime)
        {
            var option = new MemoryCacheEntryOptions
            {
                SlidingExpiration = cacheTime
            };

            this._cache.Set(key, value, option);

            return this.Get<T>(key) != null;
        }

        /// <summary>
        /// 取得每個Key專屬的鎖定對象
        /// </summary>
        /// <param name="key">Cache保存號碼牌</param>
        /// <returns></returns>
        private object GetAsyncLock(string key)
        {
            var cache = MemoryCache.Default;
            //取得每個Key專屬的鎖定對象（object）
            string asyncLockKey = _asyncLockPrefix + key;
            lock (cache)
            {
                if (cache[asyncLockKey] == null) cache.Add(asyncLockKey,
                    new object(),
                    new CacheItemPolicy()
                    {
                        SlidingExpiration = new TimeSpan(0, 10, 0)
                    });
            }
            return cache[asyncLockKey];
        }
    }
}