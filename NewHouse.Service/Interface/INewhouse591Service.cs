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
    public interface INewhouse591Service
    {
        /// <summary>
        /// 抓取指定hid的新建案
        /// </summary>
        /// <param name="hid"></param>
        /// <returns></returns>
        Task<Newhouse591Dto> FetchNewhouseAsync(int hid);

        /// <summary>
        /// 指定新建案是否存在
        /// </summary>
        /// <param name="hid"></param>
        /// <returns></returns>
        Task<bool> ExistAsync(int hid);

        /// <summary>
        /// 新增新建案
        /// </summary>
        /// <param name="newhouse"></param>
        /// <returns></returns>
        Task<IResult> InsertAsync(Newhouse591Dto newhouse);

        /// <summary>
        /// 更新新建案
        /// </summary>
        /// <param name="newhouse"></param>
        /// <returns></returns>
        Task<IResult> UpdateAsync(Newhouse591Dto newhouse);
    }
}