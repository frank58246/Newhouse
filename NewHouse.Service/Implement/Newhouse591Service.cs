using AutoMapper;
using NewHouse.Common.Extension;
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
    public class Newhouse591Service : INewhouse591Service
    {
        private readonly INewhouse591Repository _newhouse591Repository;

        private readonly INewhouseConverter _newhouseConverter;

        private readonly IMapper _mapper;

        public Newhouse591Service(IMapper mapper,
            INewhouse591Repository newhouse591Repository,
            INewhouseConverter newhouseConverter)
        {
            this._mapper = mapper;
            this._newhouse591Repository = newhouse591Repository;
            this._newhouseConverter = newhouseConverter;
        }

        public async Task<bool> ExistAsync(int hid)
        {
            return await this._newhouse591Repository.ExistAsync(hid);
        }

        public async Task<Newhouse591Dto> FetchNewhouseAsync(int hid)
        {
            var html = await this._newhouse591Repository.FetchDetailHtmlAsync(hid);

            var newhouse591Dto = await this._newhouseConverter.ConvertTo591DtoAsync(html, hid);

            if (newhouse591Dto is null || newhouse591Dto.BuildName.IsNullOrEmpty())
            {
                return null;
            }

            return newhouse591Dto;
        }

        public async Task<IEnumerable<Newhouse591Dto>> GetAllAsync()
        {
            var models = await this._newhouse591Repository.GetAllAsync();

            return this._mapper.Map<List<Newhouse591Dto>>(models);
        }

        public async Task<IResult> InsertAsync(Newhouse591Dto newhouse)
        {
            var model = this._mapper.Map<Newhouse591Model>(newhouse);
            return await this._newhouse591Repository.InsertAsync(model);
        }

        public async Task<IResult> UpdateAsync(Newhouse591Dto newhouse)
        {
            // TODO update
            return new Result();
        }
    }
}