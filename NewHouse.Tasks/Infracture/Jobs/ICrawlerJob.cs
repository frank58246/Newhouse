using Hangfire;
using Hangfire.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewHouse.Tasks.Infracture.Jobs
{
    /// <summary>
    /// 爬取外部新建案Job
    /// </summary>
    public interface ICrawlerJob
    {
        [AutomaticRetry(Attempts = 0)]
        void FetchAllNewHouse(PerformContext context, int pageSize);

        [AutomaticRetry(Attempts = 0)]
        Task FetchNewHouseAsync(PerformContext context, int startHid, int endHid);
    }
}