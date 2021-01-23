using System;
using System.Collections.Generic;
using System.Text;

namespace NewHouse.Common.Caching
{
    public interface ICacheManagerProvider
    {
        ICacheManager GetMemoryCacheManager();

        ICacheManager GetDistrubuteCacheManager();
    }
}