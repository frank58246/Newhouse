﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NewHouse.Service.Dtos
{
    public class NewhouseSimpleDto
    {/// <summary>
     /// Sid
     /// </summary>
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
        public string County { get; set; }

        /// <summary>
        /// 行政區
        /// </summary>
        public string District { get; set; }
    }
}