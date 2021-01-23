using MessagePack;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewHouse.Repository.Model
{
    /// <summary>
    /// 新建案的Model
    /// </summary>
    [MessagePackObject]
    public class NewhouseModel
    {
        /// <summary>
        /// Sid
        /// </summary>
        [Key(0)]
        public int Sid { get; set; }

        /// <summary>
        /// Hid，對應Newhouse591.HID
        /// </summary>
        [Key(1)]
        public int? Hid { get; set; }

        /// <summary>
        /// 建案名稱
        /// </summary>
        [Key(2)]
        public string BuildName { get; set; }

        /// <summary>
        /// 建案介紹
        /// </summary>
        [Key(3)]
        public string Info { get; set; }

        /// <summary>
        /// 最高單價
        /// </summary>
        [Key(4)]
        public double? HighPinPrice { get; set; }

        /// <summary>
        /// 最低單價
        /// </summary>
        [Key(5)]
        public double? LowPinPrice { get; set; }

        /// <summary>
        /// 最高總價
        /// </summary>
        [Key(6)]
        public double? HighPrice { get; set; }

        /// <summary>
        /// 最低總價
        /// </summary>
        [Key(7)]
        public double? LowPrice { get; set; }

        /// <summary>
        /// 縣市
        /// </summary>
        [Key(8)]
        public string County { get; set; }

        /// <summary>
        /// 行政區
        /// </summary>
        [Key(9)]
        public string District { get; set; }

        /// <summary>
        /// 更新時間
        /// </summary>
        [Key(10)]
        public DateTime UpdateTime { get; set; }
    }
}