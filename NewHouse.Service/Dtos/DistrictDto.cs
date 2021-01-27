using System;
using System.Collections.Generic;
using System.Text;

namespace NewHouse.Service.Dtos
{
    /// <summary>
    /// 行政區的Dto
    /// </summary>
    public class DistrictDto
    {
        /// <summary>
        /// 縣市名稱
        /// </summary>
        public string CountyName { get; set; }

        /// <summary>
        /// 縣市的SID
        /// </summary>
        public int CountySID { get; set; }

        /// <summary>
        /// 區域名稱
        /// </summary>
        public string DistrictName { get; set; }
    }
}