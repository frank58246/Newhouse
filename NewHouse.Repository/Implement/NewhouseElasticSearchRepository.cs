using Nest;
using NewHouse.Common.Constants;
using NewHouse.Common.Model;
using NewHouse.Repository.Interface;
using NewHouse.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHouse.Repository.Implement
{
    public class NewhouseElasticSearchRepository : ElasticSearchBaseRepository,
        INewhouseElasticSearchRepository
    {
        public NewhouseElasticSearchRepository(IElasticClient elasticClient) : base(elasticClient)
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

        public async Task<PageModel<NewhouseESModel>> SearchByAreaAsync(IEnumerable<string> areas)
        {
            //TODO　串接真正的邏輯

            var searchResult = _elasticClient.Search<NewhouseESModel>(x => x
                .Index(_indexName)
                .Query(query => query
                    .Term(term => term
                        .Field(field => field.County.Suffix("keyword"))
                        .Value("花蓮縣")
                    )
                )
            );

            return new PageModel<NewhouseESModel>();
        }
    }
}