using System;
using System.Collections.Generic;
using System.Text;

namespace NewHouse.Common.Constants
{
    public static class ProjectConstants
    {
        public static class HtmlSelector
        {
            public static class NewHouse
            {
                public static string BuildName = ".build_label > h1";

                public static string Info = ".info_title:contains('特色說明') + div > p ";

                // 基本資訊
                private static Func<string, string> BasicInfo = key
                    => $" dt:contains('{key}') + dd";

                public static string PinPrice = BasicInfo("單價");
                public static string Price = BasicInfo("總價");
                public static string ParkingPrice = BasicInfo("車位價格");
                public static string PublicSale = BasicInfo("公開銷售");
                public static string HouseDeliveries = BasicInfo("交屋屋況");
                public static string HousePlan = BasicInfo("格局規劃");
                public static string CaseType = BasicInfo("建案類別");
                public static string Address = BasicInfo("基地地址");
                public static string ReceptionAddress = BasicInfo("接待會館");
                public static string InvestCompany = BasicInfo("投資建設");
                public static string ConstructionCompany = BasicInfo("營造公司");
            }
        }

        public static class ElasticSearchIndex
        {
            public static string Newhouse = "newhouse";
        }

        public static class Caching
        {
            public static class NewHouse
            {
                public static string KeyPrefix = "NewhouseModel::";

                public static Func<int, string> CacheKey =
                    hid => $"{KeyPrefix}{hid}";
            }
        }
    }
}