using NewHouse.Common.Model;
using NewHouse.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewHouse.Service.Interface
{
    public interface INewhouseService
    {
        Task<NewhouseDto> GetAsync(int hid);

        Task<IResult> InsertAsync(NewhouseDto newhouseDto);

        Task<IResult> UpdateAsync(NewhouseDto newhouseDto);
    }
}