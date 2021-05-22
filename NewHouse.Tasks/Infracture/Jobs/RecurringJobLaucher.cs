using Hangfire;
using Hangfire.MissionControl;
using Hangfire.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewHouse.Tasks.Infracture.Jobs
{
    [MissionLauncher(CategoryName = "RecurringJobLaucher")]
    public class RecurringJobLaucher
    {
        [Mission(Name = "FetchNewHouseAsync",
                 Description = "抓取所有591新建案")]
        public void EnqueueFetchAllNewHouseJob(string cron)
        {
            RecurringJob.AddOrUpdate<ICrawlerJob>(j =>
                j.FetchAllNewHouse(null, 500), cron);
        }

        [Mission(Name = "SyncAllAsync",
                 Description = "將591資料同步到本地的資料庫")]
        public void EnqueueSyncAllJob(string cron)
        {
            RecurringJob.AddOrUpdate<ISyncJob>(j =>
                j.SyncAllAsync(null), cron);
        }
    }
}