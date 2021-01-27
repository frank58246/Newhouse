using NewHouse.Repository.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewHouse.Repository.Interface
{
    /// <summary>
    /// 行政區域的repository
    /// </summary>
    public interface IDistirctRepository
    {
        Task<IEnumerable<DistrictModel>> GetAllAsync();
    }
}