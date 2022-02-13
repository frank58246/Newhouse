using NewHouse.Common.Caching;
using NewHouse.Repository.Interface;
using NewHouse.Repository.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewHouse.Repository.Implement.Decorator
{
    public class CachedDistirctRepository : IDistirctRepository
    {
        private readonly ICacheManager _cacheManager;

        private readonly IDistirctRepository _distirctRepository;

        public CachedDistirctRepository(ICacheManagerProvider cacheManagerProvider,
            IDistirctRepository distirctRepository)
        {
            this._cacheManager = cacheManagerProvider.GetMemoryCacheManager();
            this._distirctRepository = distirctRepository;
        }

        public async Task<IEnumerable<DistrictModel>> GetAllAsync()
        {
            var cacheKey = $"CachedDistirctRepository-{nameof(GetAllAsync)}";
            var cache = this._cacheManager.Get<IEnumerable<DistrictModel>>(cacheKey);
            if (cache != null)
            {
                return cache;
            }
            var models = await this._distirctRepository.GetAllAsync();
            if (models != null)
            {
                this._cacheManager.Save(cacheKey, models);
            }

            return models;
        }
    }
}