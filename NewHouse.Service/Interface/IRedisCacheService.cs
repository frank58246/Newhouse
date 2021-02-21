using NewHouse.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewHouse.Service.Interface
{
    public interface IRedisCacheService
    {
        IResult DeleteNewhouseCache(int sid);
    }
}