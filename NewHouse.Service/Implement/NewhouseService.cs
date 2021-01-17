using AutoMapper;
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
        private readonly INewhouse591Repository _newhouse591Repository;

        private readonly IMapper _mapper;

        public NewhouseService(IMapper mapper,
            INewhouse591Repository newhouse591Repository)
        {
            this._mapper = mapper;
            this._newhouse591Repository = newhouse591Repository;
        }

        public async Task<bool> ExistAsync(int hid)
        {
            return await this._newhouse591Repository.ExistAsync(hid);
        }

        public async Task<Newhouse591Dto> FetchNewhouseAsync(int hid)
        {
            var model = await this._newhouse591Repository.FetchAsync(hid);
            return this._mapper.Map<Newhouse591Dto>(model);
        }

        public async Task<IResult> InsertAsync(Newhouse591Dto newhouse)
        {
            var model = this._mapper.Map<Newhouse591Model>(newhouse);
            return await this._newhouse591Repository.InsertAsync(model);
        }

        public Task<IResult> UpdateAsync(Newhouse591Dto newhouse)
        {
            throw new NotImplementedException();
        }
    }
}