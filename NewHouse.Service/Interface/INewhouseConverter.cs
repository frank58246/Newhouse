using NewHouse.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewHouse.Service.Interface
{
    public interface INewhouseConverter
    {
        Task<NewhouseDto> CovertAsync(Newhouse591Dto newhouse591Dto);

        Task<Newhouse591Dto> ConvertTo591DtoAsync(string htmlString, int hid);
    }
}