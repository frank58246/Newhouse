using AngleSharp;
using AngleSharp.Dom;
using Flurl;
using NewHouse.Common.Extension;
using NewHouse.Common.Helper;
using NewHouse.Repository.Interface;
using NewHouse.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NewHouse.Repository.Implement
{
    public class Newhouse591Repository : APIBaseRepository,INewhouse591Repository
    {
        public Newhouse591Repository(HttpClient httpClient, IWebsiteUrlHelper websiteUrlHelper)
            : base(httpClient, websiteUrlHelper)
        {
        }

        public async Task<NewhouseModel> FetchAsync(int hid)
        {
            var baseUrl = this._websiteUrlHelper.NewHouse591;
            var url = baseUrl.AppendPathSegment("/home/housing/info")
                             .SetQueryParam("hid", hid);

            var config = Configuration.Default;
            var context = BrowsingContext.New(config);

            var response = await this._httpClient.GetAsync(url);
            var responseString = await response.ContentStringAsync();

            var document = await context.OpenAsync(res => res.Content(responseString));

            var model = new NewhouseModel
            {
                BuildName = this.GetSingleValue(document, ""),
            };

            return model ;
        }

        private string GetSingleValue(IDocument document,string selector)
        {
            var values = document.QuerySelectorAll(selector);
            if (values is null || values.Count() == 0)
            {
                return "";
            }

            return values.SingleOrDefault().TextContent;
        }


    }
}
