using AutoMapper;
using Hangfire.Console;
using Hangfire.Server;
using NewHouse.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewHouse.Tasks.Infracture.Jobs
{
    public class SyncJob : ISyncJob
    {
        private readonly IMapper _mapper;

        private readonly INewhouse591Service _newhouse591Service;

        private readonly INewhouseService _newhouseService;

        private readonly INewhouseConverter _newhouseConverter;

        public SyncJob(IMapper mapper,
            INewhouse591Service newhouse591Service,
            INewhouseService newhouseService,
            INewhouseConverter newhouseConverter)
        {
            this._mapper = mapper;
            this._newhouse591Service = newhouse591Service;
            this._newhouseService = newhouseService;
            this._newhouseConverter = newhouseConverter;
        }

        public async Task SyncAllAsync(PerformContext context)
        {
            context.WriteLine($"{DateTime.Now}: 開始撈取資料庫591資料");
            var all591House = await this._newhouse591Service.GetAllAsync();

            context.WriteLine($"{DateTime.Now}: 591資料共計{all591House.Count()}筆");

            foreach (var newhouse591 in all591House)
            {
                var newhouseDto = await this._newhouseConverter.CovertAsync(newhouse591);
                var newhouseInDatabase = await this._newhouseService
                    .GetAsync(newhouseDto.Hid.GetValueOrDefault());
                if (newhouseInDatabase is null)
                {
                    await this._newhouseService.InsertAsync(newhouseDto);
                    context.WriteLine($"{DateTime.Now} 新增HID:{newhouseDto.Hid}，{newhouseDto.BuildName}");
                }
                else
                {
                    // update
                }

                context.WriteLine($"{DateTime.Now} Job結束");
            }
        }
    }
}