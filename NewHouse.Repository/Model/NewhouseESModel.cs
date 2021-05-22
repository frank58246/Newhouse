using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewHouse.Repository.Model
{
    [ElasticsearchType(RelationName = "newhouse")]
    public class NewhouseESModel
    {
        public int Sid { get; set; }

        /// <summary>
        /// 建案名稱
        /// </summary>
        public string BuildName { get; set; }

        /// <summary>
        /// 最高單價
        /// </summary>
        public double HighPinPrice { get; set; }

        /// <summary>
        /// 最低單價
        /// </summary>
        public double LowPinPrice { get; set; }

        /// <summary>
        /// 最高總價
        /// </summary>
        public double HighPrice { get; set; }

        /// <summary>
        /// 最低總價
        /// </summary>
        public double LowPrice { get; set; }

        /// <summary>
        /// 縣市
        /// </summary>
        [Keyword]
        public string County { get; set; }

        /// <summary>
        /// 行政區
        /// </summary>
        [Keyword]
        public string District { get; set; }
    }
}