﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NewHouse.Repository.Model
{
    public class NewhouseSearchParameterModel
    {
        /// <summary>
        /// 起始筆數，預設為1
        /// </summary>
        public int Start { get; set; }

        /// <summary>
        /// 抓取筆數，預設為20
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 縣市行政區域
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