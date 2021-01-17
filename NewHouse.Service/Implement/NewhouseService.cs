using NewHouse.Common.Model;
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
        public Task<bool> Exist(int hid)
        {
            throw new NotImplementedException();
        }

        public NewhouseDto FetchNewhouse(int hid)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> InsertAsync(NewhouseDto newhouse)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> UpdateAsync(NewhouseDto newhouse)
        {
            throw new NotImplementedException();
        }

        Task<NewhouseDto> INewhouseService.FetchNewhouse(int hid)
        {
            throw new NotImplementedException();
        }
    }
}
