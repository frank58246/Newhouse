﻿using AutoMapper;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using NewHouse.Common.Caching;
using NewHouse.Common.Constants;
using NewHouse.Common.Helper;
using NewHouse.Repository.Implement;
using NewHouse.Repository.Implement.Decorator;
using NewHouse.Repository.Interface;
using NewHouse.Repository.Model;
using NewHouse.Service.Mapping;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;

namespace Newhouse.DependencyInjection
{
    /// <summary>
    /// 共用的DI
    /// </summary>
    public static class DependencyInjectionExtension
    {
        public static void AddCommonDependencyInjection(this IServiceCollection services,
          IConfiguration configuration)
        {
            services.AddSingleton<HttpClient>();

            AddConfig(services, configuration);

            AddDecorator(services);

            AddCache(services);

            AddElasticSearch(services);
        }

        private static void AddConfig(this IServiceCollection services,
          IConfiguration configuration)
        {
            var config = new ConnectionSetting();
            configuration.Bind("ConnectionSetting", config);
            services.AddSingleton(config);
        }

        private static void AddCache(this IServiceCollection services)
        {
            services.AddMemoryCache();

            var databaseHelper = services.BuildServiceProvider()
                .GetService<IDatabaseHelper>();

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = databaseHelper.Redis;
                options.InstanceName = "NewHouse";
            });

            var serviceProvider = services.BuildServiceProvider();
            var defaultCacheTime = TimeSpan.FromMinutes(30);

            var memoryCache = serviceProvider.GetService<IMemoryCache>();
            var memoryCacheManager = new MemoryCacheManager(memoryCache, defaultCacheTime);
            services.AddSingleton<ICacheManager>(memoryCacheManager);

            var distributeCache = serviceProvider.GetService<IDistributedCache>();
            var distributeCacheManager = new DistributeCacheManger(distributeCache, defaultCacheTime);
            services.AddSingleton<ICacheManager>(distributeCacheManager);

            services.AddSingleton<ICacheManagerProvider>(x =>
                 new CacheManagerProvider(memoryCacheManager, distributeCacheManager)
            );
        }

        private static void AddDecorator(this IServiceCollection services)
        {
            services.AddTransient<INewhouseRepository, NewhouseRepository>()
                   .Decorate<INewhouseRepository, CachedNewhouseRepository>();

            services.AddTransient<IDistirctRepository, DistirctRepository>()
                .Decorate<IDistirctRepository, CachedDistirctRepository>();
        }

        private static void AddElasticSearch(this IServiceCollection services)
        {
            var databaseHelper = services.BuildServiceProvider()
                             .GetService<IDatabaseHelper>();

            var uri = new Uri(databaseHelper.ElasticSearch);
            var settings = new ConnectionSettings(uri)
                .DefaultIndex(ProjectConstants.ElasticSearchIndex.Default)
                .DefaultMappingFor<NewhouseESModel>(m => m
                .IndexName(ProjectConstants.ElasticSearchIndex.Newhouse));

            var elasticSearchClient = new ElasticClient(settings);
            services.AddSingleton<IElasticClient>(elasticSearchClient);

            services.AddSingleton<IElasticClient>(elasticSearchClient);
        }
    }
}