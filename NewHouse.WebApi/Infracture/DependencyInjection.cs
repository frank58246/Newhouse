using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewHouse.Common.Helper;
using NewHouse.Service.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewHouse.WebApi.Infracture
{
    public static class DependencyInjection
    {
        public static void AddConfig(this IServiceCollection services,
           IConfiguration configuration)
        {
            var config = new ConnectionSetting();
            configuration.Bind("ConnectionSetting", config);
            services.AddSingleton(config);
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

        public static void AddCache(this IServiceCollection services)
        {
            services.AddMemoryCache();

            var databaseHelper = services.BuildServiceProvider()
                                         .GetService<IDatabaseHelper>();

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = databaseHelper.Redis;
                options.InstanceName = "NewHouse";
            });
        }
    }
}