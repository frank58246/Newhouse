using NewHouse.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewHouse.Service.Interface
{
    public interface IRedisCacheService
    {
        Task<IResult> DeleteNewhouseCache(int hid);
    }
}