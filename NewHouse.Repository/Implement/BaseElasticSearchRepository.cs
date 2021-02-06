using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewHouse.Repository.Implement
{
    /// <summary>
    /// BaseElasticSearchRepository
    /// </summary>
    public abstract class BaseElasticSearchRepository
    {
        private readonly IElasticClient _elasticClient;

        public BaseElasticSearchRepository(IElasticClient elasticClient)
        {
            this._elasticClient = elasticClient;
        }
    }
}