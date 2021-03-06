﻿using Nest;
using NewHouse.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Result = NewHouse.Common.Model.Result;

namespace NewHouse.Repository.Implement
{
    /// <summary>
    /// BaseElasticSearchRepository
    /// </summary>
    public abstract class ElasticSearchBaseRepository
    {
        protected readonly IElasticClient _elasticClient;

        protected abstract string _indexName { get; }

        public ElasticSearchBaseRepository(IElasticClient elasticClient)
        {
            this._elasticClient = elasticClient;
        }

        public async Task<bool> ExistIndexAsync()
        {
            var response = await this._elasticClient.Indices.
                    ExistsAsync(this._indexName);

            return response.Exists;
        }

        public async Task<IResult> CheckOrCreateIndexAsync<T>() where T : class
        {
            var existIndex = await this.ExistIndexAsync();

            if (existIndex)
            {
                return new Result
                {
                    Success = true
                };
            }

            var createResponse = await this._elasticClient.Indices
                .CreateAsync(this._indexName, c => c.Map<T>(m => m.AutoMap()));

            var result = new Result()
            {
                Success = createResponse.IsValid,
                Message = createResponse.DebugInformation
            };
            return result;
        }

        public async Task<IResult> BulkIndexAsync<T>(IEnumerable<T> documents)
            where T : class
        {
            var bulkIndexResponse = await this._elasticClient.BulkAsync(b => b
                 .Index(this._indexName)
                 .IndexMany(documents));

            var result = new Result
            {
                Success = bulkIndexResponse.IsValid,
                AffectRow = bulkIndexResponse.Items.Count()
            };

            return result;
        }

        public async Task<PageModel<T>> SearchAsync<T>(SearchRequest request)
            where T : class
        {
            var result = await this._elasticClient.SearchAsync<T>(request);

            var pageModel = new PageModel<T>
            {
                Start = request.From ?? 0, // es default
                Size = request.Size ?? 10, // es default
                Data = result.Documents,
                Total = result.Total
            };

            return pageModel;
        }

        public async Task<IResult> DeleteAllAsync<T>() where T : class
        {
            var response = await this._elasticClient.
                DeleteByQueryAsync<T>(q => q.MatchAll());

            var result = new Result()
            {
                Success = response.IsValid,
                Message = response.DebugInformation
            };

            return result;
        }
    }
}