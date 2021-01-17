using System;
using System.Collections.Generic;
using System.Text;

namespace NewHouse.Service.Dtos
{
    /// <summary>
    /// 新建案Dto
    /// </summary>
    public class NewhouseDto
    {
        /// <summary>
        /// Hid
        /// </summary>
        public int Hid { get; set; }

        /// <summary>
        /// 新建案名稱
        /// </summary>
        public string BuildName { get; set; }
    }
}
