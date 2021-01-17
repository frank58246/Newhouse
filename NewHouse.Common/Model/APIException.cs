using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace NewHouse.Common.Model
{
    /// <summary>
    /// API的例外物件
    /// </summary>
    public class APIException: Exception
    {
        public string Url { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public string Content { get; set; }
    }
}
