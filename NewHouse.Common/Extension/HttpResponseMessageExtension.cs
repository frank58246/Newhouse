using NewHouse.Common.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NewHouse.Common.Extension
{
    public static class HttpResponseMessageExtension
    {
        public static async Task<T> ContentAsync<T>(this HttpResponseMessage responseMessage)
        {
            var responseString = await responseMessage.Content.ReadAsStringAsync();


            if (responseMessage.StatusCode != HttpStatusCode.OK)
            {
                var exception = new APIException()
                {
                    StatusCode = responseMessage.StatusCode,
                    Url = responseMessage.RequestMessage.RequestUri.AbsoluteUri.ToString(),
                    Content = responseString
                };
                throw exception;
            }

            try
            {
                var response = JsonConvert.DeserializeObject<T>(responseString);
                return response;
            }
            catch (Exception)
            {

                var exception = new APIException()
                {
                    StatusCode = responseMessage.StatusCode,
                    Url = responseMessage.RequestMessage.RequestUri.AbsoluteUri.ToString(),
                    Content = responseString
                };
                throw exception;
            }
        
        }
       
    }
}
