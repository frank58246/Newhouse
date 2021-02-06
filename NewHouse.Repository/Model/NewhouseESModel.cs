using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewHouse.Repository.Model
{
    [ElasticsearchType(RelationName = "newhouse")]
    public class NewhouseESModel
    {
        [Text(Name = "buildName")]
        public string BuildName { get; set; }

        [Number(Name = "highPinPrice")]
        public double HighPinPrice { get; set; }

        [Number(Name = "lowPinPrice")]
        public double LowPinPrice { get; set; }

        [Number(Name = "highPrice")]
        public double HighPrice { get; set; }

        [Number(Name = "lowPrice")]
        public double LowPrice { get; set; }

        [Keyword(Name = "county")]
        public string County { get; set; }

        [Keyword(Name = "district")]
        public string District { get; set; }
    }
}