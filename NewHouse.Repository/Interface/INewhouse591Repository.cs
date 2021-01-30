using NewHouse.Common.Model;
using NewHouse.Repository.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewHouse.Repository.Interface
{
    public interface INewhouse591Repository
    {
        Task<string> FetchDetailHtmlAsync(int hid);

        Task<IResult> InsertAsync(Newhouse591Model model);

        Task<bool> ExistAsync(int hid);

        Task<IEnumerable<Newhouse591Model>> GetAllAsync();
    }
}