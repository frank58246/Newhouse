using NewHouse.Common.Model;
using NewHouse.Repository.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewHouse.Repository.Interface
{
    public interface INewhouseRepository
    {
        Task<IResult> InsertAsync(NewhouseModel newhouseModel);

        Task<NewhouseModel> GetAsync(int sid);

        Task<IResult> UpdateAsync(NewhouseModel newhouseModel);
    }
}