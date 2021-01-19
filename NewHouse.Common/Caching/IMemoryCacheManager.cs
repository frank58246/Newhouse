using System;
using System.Collections.Generic;
using System.Text;

namespace NewHouse.Common.Caching
{
    public interface IMemoryCacheManager
    {
        T Get<T>(string key);

        bool Save<T>(string key, T value);
    }
}