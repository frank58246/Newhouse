using Hangfire.Console;
using Hangfire.Server;
using NewHouse.Service.Implement;
using NewHouse.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewHouse.Tasks.Infracture.Jobs
{
    /// <summary>
    /// 爬蟲Job
    /// </summary>
    public class CrawlerJob : ICrawlerJob
    {
        private readonly INewhouseService _newhouseService;

        public CrawlerJob(INewhouseService newhouseService)
        {
            this._newhouseService = newhouseService;
        }

        public async Task FetchNewHouseAsync(PerformContext context, int hid)
        {
            context.WriteLine($"{DateTime.Now} 開始抓取591新建案，hid:{hid}");
            var newhouse = await this._newhouseService.FetchNewhouseAsync(hid);

            var exist = await this._newhouseService.ExistAsync(hid);
            if (exist)
            {
                //var upateResult = await this._newhouseService.UpdateAsync(newhouse);
                //context.WriteLine($"{DateTime.Now} 更新591新建案，hid:{hid}");
            }
            else
            {
                var inserttResult = await this._newhouseService.InsertAsync(newhouse);
                context.WriteLine($"{DateTime.Now} 新增hid:{hid}591新建案");
            }

            context.WriteLine($"{DateTime.Now} Job結束");
        }
    }
}