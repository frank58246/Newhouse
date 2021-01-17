using NewHouse.Common.Model;
using NewHouse.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewHouse.Service.Interface
{
    /// <summary>
    /// 新建案服務
    /// </summary>
   public  interface INewhouseService
   {
        /// <summary>
        /// 抓取指定hid的新建案
        /// </summary>
        /// <param name="hid"></param>
        /// <returns></returns>
        Task<NewhouseDto> FetchNewhouse(int hid);

        /// <summary>
        /// 指定新建案是否存在
        /// </summary>
        /// <param name="hid"></param>
        /// <returns></returns>
        Task<bool> Exist(int hid);

        /// <summary>
        /// 新增新建案
        /// </summary>
        /// <param name="newhouse"></param>
        /// <returns></returns>
        Task<IResult> InsertAsync(NewhouseDto newhouse);

        /// <summary>
        /// 更新新建案
        /// </summary>
        /// <param name="newhouse"></param>
        /// <returns></returns>
        Task<IResult> UpdateAsync(NewhouseDto newhouse);
    }
}
