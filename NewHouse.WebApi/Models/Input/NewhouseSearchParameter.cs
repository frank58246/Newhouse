using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewHouse.WebApi.Models.Input
{
    public class NewhouseSearchParameter
    {
        /// <summary>
        /// 1: 區域搜尋; 2: 總價搜尋
        /// </summary>
        public int SeaarchMode { get; set; }

        /// <summary>
        /// 起始筆數，預設為1
        /// </summary>
        public int Start { get; set; }

        /// <summary>
        /// 抓取筆數，預設為20
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 縣市行政區域，用底線分隔，如"台中市_大里區"
        /// </summary>
        public List<string> Areas { get; set; }

        /// <summary>
        /// 最高價
        /// </summary>
        public double HighPrice { get; set; }

        /// <summary>
        /// 最低價
        /// </summary>
        public double LowPrice { get; set; }
    }
}