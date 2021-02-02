using System;
using System.Collections.Generic;
using System.Text;

namespace NewHouse.Common.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);

        bool Save<T>(string key, T value);

        bool Save<T>(string key, T value, TimeSpan timeSpan);
    }
}