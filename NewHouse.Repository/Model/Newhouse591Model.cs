using System;
using System.Collections.Generic;
using System.Text;

namespace NewHouse.Repository.Model
{
    /// <summary>
    /// 591新建案Model
    /// </summary>
    public class Newhouse591Model
    {
        /// <summary>
        /// Hid
        /// </summary>
        public int Hid { get; set; }

        /// <summary>
        /// 建案名稱
        /// </summary>
        public string BuildName { get; set; }

        /// <summary>
        /// 建案介紹
        /// </summary>
        public string Info { get; set; }

        /// <summary>
        /// 單價
        /// </summary>
        public string PinPrice { get; set; }

        /// <summary>
        /// 總價
        /// </summary>
        public string Price { get; set; }

        /// <summary>
        /// 停車位價格
        /// </summary>
        public string ParkingPrice { get; set; }

        /// <summary>
        /// 銷售狀態
        /// </summary>
        public string PublicSale { get; set; }

        /// <summary>
        /// 交屋狀況
        /// </summary>
        public string HouseDeliveries { get; set; }

        /// <summary>
        /// 建築規劃
        /// </summary>
        public string HousePlan { get; set; }

        /// <summary>
        /// 建案類別
        /// </summary>
        public string CaseType { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 接待地址
        /// </summary>
        public string ReceptionAddress { get; set; }

        /// <summary>
        /// 投資建造公司
        /// </summary>
        public string InvestCompany { get; set; }

        /// <summary>
        /// 建設公司
        /// </summary>
        public string ConstructionCompany { get; set; }

        /// <summary>
        /// 更新時間
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}