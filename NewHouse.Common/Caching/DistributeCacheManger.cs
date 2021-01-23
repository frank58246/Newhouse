using MessagePack;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using System.Text;

namespace NewHouse.Common.Caching
{
    public class DistributeCacheManger : ICacheManager
    {
        //加入Lock機制限定同一Key同一時間只有一個Callback執行
        private const string _asyncLockPrefix = "$$MemoryCacheAsyncLock#";

        private IDistributedCache _cache;

        public DistributeCacheManger(IDistributedCache cache)
        {
            this._cache = cache;
        }

        public T Get<T>(string key)
        {
            lock (GetAsyncLock(key))
            {
                var bytes = this._cache.Get(key);
                if (bytes != null)
                {
                    return MessagePackSerializer.Deserialize<T>(bytes);
                }

                return default(T);
            }
        }

        public bool Save<T>(string key, T value)
        {
            var bytes = MessagePackSerializer.Serialize(value);
            this._cache.Set(key, bytes);
            return this._cache.Get(key) != null;
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