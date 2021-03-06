﻿using AutoMapper;
using NewHouse.Common.Enums;
using NewHouse.Common.Model;
using NewHouse.Repository.Interface;
using NewHouse.Repository.Model;
using NewHouse.Service.Dtos;
using NewHouse.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewHouse.Service.Implement
{
    public class NewhouseService : INewhouseService
    {
        private readonly INewhouseRepository _newhouseRepository;

        private readonly INewhouseElasticSearchRepository
            _newhouseElasticSearchRepository;

        private readonly IMapper _mapper;

        public NewhouseService(IMapper mapper,
            INewhouseRepository newhouseRepository,
            INewhouseElasticSearchRepository newhouseElasticSearchRepository)
        {
            this._mapper = mapper;
            this._newhouseRepository = newhouseRepository;
            this._newhouseElasticSearchRepository = newhouseElasticSearchRepository;
        }

        public async Task<IEnumerable<NewhouseDto>> GetAllAsync()
        {
            var model = await this._newhouseRepository.GetAllAsync();

            return this._mapper.Map<List<NewhouseDto>>(model);
        }

        public async Task<NewhouseDto> GetAsync(int hid)
        {
            if (hid == 0)
            {
                throw new ArgumentNullException(nameof(hid));
            }
            var newhouseModel = await this._newhouseRepository.GetAsync(hid);

            return this._mapper.Map<NewhouseDto>(newhouseModel);
        }

        public async Task<IResult> InsertAsync(NewhouseDto newhouseDto)
        {
            var newhouseModel = this._mapper.Map<NewhouseModel>(newhouseDto);

            newhouseModel.UpdateTime = DateTime.Now;

            return await this._newhouseRepository.InsertAsync(newhouseModel);
        }

        public async Task<PageModel<NewhouseSimpleDto>> SearchAsync(NewhouseSearchParameterDto parameter)
        {
            var parameterModel = this._mapper.Map<NewhouseSearchParameterModel>(parameter);

            var searchResult = await this._newhouseElasticSearchRepository.SearchAreaAsync(parameterModel);

            var pageDto = new PageModel<NewhouseSimpleDto>()
            {
                Start = searchResult.Start,
                Size = searchResult.Size,
                Data = this._mapper.Map<List<NewhouseSimpleDto>>(searchResult.Data),
                Total = searchResult.Total
            };

            return pageDto;
        }

        public async Task<IResult> SyncElasticSearchAsync(IEnumerable<NewhouseDto> newhouseDtos)
        {
            IResult result;
            result = await this._newhouseElasticSearchRepository.CheckOrCreateIndexAsync();

            if (result.Success.Equals(false))
            {
                return result;
            }

            result = await this._newhouseElasticSearchRepository.DeleteAllAsync();

            if (result.Success.Equals(false))
            {
                return result;
            }

            var sources = this._mapper
                .Map<IEnumerable<NewhouseESModel>>(newhouseDtos);

            return await this._newhouseElasticSearchRepository
                        .InsertAsync(sources);
        }

        public async Task<IResult> UpdateAsync(NewhouseDto newhouseDto)
        {
            var newhouseModel = this._mapper.Map<NewhouseModel>(newhouseDto);

            newhouseModel.UpdateTime = DateTime.Now;

            return await this._newhouseRepository.UpdateAsync(newhouseModel);
        }
    }
}