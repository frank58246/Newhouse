using Hangfire.Console;
using Hangfire.MissionControl;
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
    [MissionLauncher(CategoryName = "Crawler")]
    public class CrawlerJob : ICrawlerJob
    {
        private readonly INewhouse591Service _newhouseService;

        public CrawlerJob(INewhouse591Service newhouseService)
        {
            this._newhouseService = newhouseService;
        }

        [Mission(Name = "FetchNewHouseAsync",
                 Description = "抓取所有新建案")]
        public async Task FetchNewHouseAsync(PerformContext context, int startHid, int endHid)
        {
            var hids = new List<int>();
            for (int i = startHid; i < endHid; i++)
            {
                hids.Add(i);
            }

            context.WriteLine($"{DateTime.Now} 抓取hid{startHid}至{endHid}591新建案，" +
                $"共計{endHid - startHid}筆");

            var bar = context.WriteProgressBar();
            foreach (var hid in hids.WithProgress(bar))
            {
                try
                {
                    context.WriteLine($"{DateTime.Now} 開始抓取591新建案，hid:{hid}");
                    var newhouse = await this._newhouseService.FetchNewhouseAsync(hid);
                    if (newhouse is null)
                    {
                        context.WriteLine($"{DateTime.Now} 查無hif{hid}新建案");
                        continue;
                    }

                    var exist = await this._newhouseService.ExistAsync(hid);
                    if (exist)
                    {
                        var upateResult = await this._newhouseService.UpdateAsync(newhouse);
                        context.WriteLine($"{DateTime.Now} 更新591新建案，hid:{hid}");
                    }
                    else
                    {
                        var inserttResult = await this._newhouseService.InsertAsync(newhouse);
                        context.WriteLine($"{DateTime.Now} 新增hid:{hid}591新建案");
                    }
                }
                catch (Exception)
                {
                    context.WriteLine($"{DateTime.Now} hid:{hid}591新建案抓取失敗");
                    continue;
                }
            }

            context.WriteLine($"{DateTime.Now} Job結束");
        }
    }
}