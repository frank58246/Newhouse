using NewHouse.Common.Extension;
using NewHouse.Common.Helper;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NewHouse.Repository.Implement
{
    /// <summary>
    /// API基礎類別
    /// </summary>
    public class APIBaseRepository
    {
        private readonly HttpClient _httpClient;

        protected readonly IWebsiteUrlHelper _websiteUrlHelper;

        public APIBaseRepository(HttpClient httpClient, IWebsiteUrlHelper websiteUrlHelper)
        {
            this._httpClient = httpClient;
            this._websiteUrlHelper = websiteUrlHelper;
        }

        public async Task<TResponse> GetAsync<TResponse>(string url)
        {
            var response = await this._httpClient.GetAsync(url);

            var result = await response.ContentAsync<TResponse>();

            return result;          
        }

    }
}
