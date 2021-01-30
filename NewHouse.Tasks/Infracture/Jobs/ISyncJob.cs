using Hangfire;
using Hangfire.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewHouse.Tasks.Infracture.Jobs
{
    /// <summary>
    /// 同步建案的Job
    /// </summary>
    public interface ISyncJob
    {
        [AutomaticRetry(Attempts = 0)]
        Task SyncAllAsync(PerformContext context);
    }
}