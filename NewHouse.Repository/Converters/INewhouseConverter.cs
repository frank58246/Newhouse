using NewHouse.Repository.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewHouse.Repository.Converters
{
    /// <summary>
    /// 新建案的converter
    /// </summary>
    public interface INewhouseConverter
    {
        /// <summary>
        /// 將網頁文字轉換為591新屋model
        /// </summary>
        /// <param name="htmlString"></param>
        /// <returns></returns>
        Task<Newhouse591Model> ConvertTo591ModelAsync(string htmlString, int hid);
    }
}