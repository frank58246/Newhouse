using Nest;
using NewHouse.Common.Constants;
using NewHouse.Common.Model;
using NewHouse.Repository.Interface;
using NewHouse.Repository.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewHouse.Repository.Implement
{
    public class NewhouseESRepository : ElasticSearchBaseRepository,
        INewhouseESRepository
    {
        public NewhouseESRepository(IElasticClient elasticClient) : base(elasticClient)
        {
        }

        protected override string _indexName =>
            ProjectConstants.ElasticSearchIndex.Newhouse;

        public async Task<IResult> CheckOrCreateIndexAsync() =>
            await this.CheckOrCreateIndexAsync<NewhouseESModel>();

        public async Task<IResult> DeleteAllAsync() =>
            await this.DeleteAllAsync<NewhouseESModel>();

        public async Task<IResult> InsertAsync(IEnumerable<NewhouseESModel> sources) =>
            await this.BulkIndexAsync(sources);
    }
}