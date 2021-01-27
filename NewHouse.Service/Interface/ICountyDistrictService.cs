using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewHouse.Service.Interface
{
    /// <summary>
    /// 縣市行政區服務
    /// </summary>
    public interface ICountyDistrictService
    {
        Task<string> GetCountyName(string address);

        Task<string> GetDistrictName(string address);
    }
}