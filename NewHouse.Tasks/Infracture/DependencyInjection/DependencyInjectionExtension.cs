using AutoMapper;
using Hangfire;
using Hangfire.Console;
using Hangfire.Dashboard;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewHouse.Common.Caching;
using NewHouse.Common.Helper;
using NewHouse.Service.Mapping;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace NewHouse.Tasks.Infracture.DependencyInjection
{
    /// <summary>
    /// DI的Extension
    /// </summary>
    public static class DependencyInjectionExtension
    {
        /// <summary>
        /// AddHangfire
        /// </summary>
        /// <param name="services"></param>
        public static void AddHangfire(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var databaseHelper = serviceProvider.GetService<IDatabaseHelper>();
            var connection = databaseHelper.Hangfire;

            services.AddHangfire(config => config
                   .UseSimpleAssemblyNameTypeSerializer()
                   .UseRecommendedSerializerSettings()
                   .UseColouredConsoleLogProvider()
                   .UseDashboardMetric(DashboardMetrics.ServerCount)
                   .UseDashboardMetric(DashboardMetrics.RecurringJobCount)
                   .UseDashboardMetric(DashboardMetrics.RetriesCount)
                   .UseDashboardMetric(DashboardMetrics.EnqueuedAndQueueCount)
                   .UseDashboardMetric(DashboardMetrics.ScheduledCount)
                   .UseDashboardMetric(DashboardMetrics.ProcessingCount)
                   .UseDashboardMetric(DashboardMetrics.SucceededCount)
                   .UseDashboardMetric(DashboardMetrics.FailedCount)
                   .UseDashboardMetric(DashboardMetrics.DeletedCount)
                   .UseDashboardMetric(DashboardMetrics.AwaitingCount)

                   .UseConsole()                                                                                                                //from Hangfire.Console
                   .UseSqlServerStorage(connection));
        }

        public static void AddMapping(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ServiceProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}