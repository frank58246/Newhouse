using NewHouse.Common.Model;
using NewHouse.Repository.Implement;
using NewHouse.Repository.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewHouse.Repository.Interface
{
    /// <summary>
    /// 新建案的ElasticSearchRepository
    /// </summary>
    public interface INewhouseElasticSearchRepository
    {
        Task<IResult> CheckOrCreateIndexAsync();

        Task<IResult> InsertAsync(IEnumerable<NewhouseESModel> sources);

        Task<IResult> DeleteAllAsync();

        Task<PageModel<NewhouseESModel>> SearchAreaAsync(NewhouseSearchParameterModel parameter);
    }
}