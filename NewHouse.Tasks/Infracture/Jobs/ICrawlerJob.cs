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
        Task FetchNewHouseAsync(PerformContext context, int hid);
    }
}
