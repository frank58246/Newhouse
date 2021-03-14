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

        public async Task<PageModel<NewhouseESModel>> SearchAreaAsync(NewhouseSearchParameterModel parameter)
        {
            //TODO　串接真正的邏輯
            var mustClauses = new List<QueryContainer>();

            var shouldClause = new List<QueryContainer>();

            if (parameter.Areas != null && parameter.Areas.Count() > 0)
            {
                // 把台北市_中正區，轉為<台北市,中正區>
                var validAreas = parameter.Areas
                    .Select(x => x.Split("_"))
                    .Where(x => x.Count() == 2)
                    .Select(x => new Tuple<string, string>(x[0], x[1]));

                foreach (var area in validAreas)
                {
                    var areaMustCluase = new List<QueryContainer>();

                    var countyQuery = new TermQuery
                    {
                        Field = Infer.Field<NewhouseESModel>(c => c.County),
                        Value = area.Item1
                    };

                    var districeQuery = new TermQuery
                    {
                        Field = Infer.Field<NewhouseESModel>(c => c.District),
                        Value = area.Item2
                    };

                    shouldClause.Add(countyQuery && districeQuery);
                }
            }

            var searchRequest = new SearchRequest(this._indexName)
            {
                From = parameter.Start,
                Size = parameter.Count,
                Query = new BoolQuery
                {
                    Must = mustClauses,
                    Should = shouldClause
                }
            };

            var result = await this.SearchAsync<NewhouseESModel>(searchRequest);

            return result;
        }
    }
}