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
            var mustClauses = new List<QueryContainer>();
            if (areas != null && areas.Count() > 0)
            {
                mustClauses.Add(new TermsQuery
                {
                    Field = Infer.Field<NewhouseESModel>(c => c.County),
                    Terms = areas
                });
            }

            var searchRequest = new SearchRequest(this._indexName)
            {
                Size = 100,
                Query = new BoolQuery { Must = mustClauses }
            };

            var res = await this.SearchAsync<NewhouseESModel>(searchRequest);

            return new PageModel<NewhouseESModel>();
        }
    }
}