using System;
using System.Collections.Generic;
using System.Text;

namespace NewHouse.Common.Model
{
    /// <summary>
    /// 操作的結果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IResult
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        bool Success { get; set; }

        /// <summary>
        /// 影響筆數
        /// </summary>
        int AffectRow { get; set; }

        /// <summary>
        /// 操作結果訊息
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
       // T Data { get; set; }
    }
}
