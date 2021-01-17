using NewHouse.Common.Model;
using NewHouse.Repository.Interface;
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

        public NewhouseService(INewhouse591Repository newhouse591Repository)
        {
            this._newhouse591Repository = newhouse591Repository;
        }

        public Task<bool> Exist(int hid)
        {
            throw new NotImplementedException();
        }

        public async Task<NewhouseDto> FetchNewhouseAsync(int hid)
        {
            var model = await this._newhouse591Repository.FetchAsync(hid);
            return null;
        }

        public Task<IResult> InsertAsync(NewhouseDto newhouse)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> UpdateAsync(NewhouseDto newhouse)
        {
            throw new NotImplementedException();
        }

    }
}
