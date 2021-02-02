using NewHouse.Common.Caching;
using NewHouse.Common.Model;
using NewHouse.Repository.Interface;
using NewHouse.Repository.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewHouse.Repository.Implement.Decorator
{
    public class CachedNewhouseRepository : INewhouseRepository
    {
        private readonly ICacheManager _cacheManager;

        private readonly INewhouseRepository _newhouseRepository;

        public CachedNewhouseRepository(ICacheManagerProvider cacheManagerProvider,
            INewhouseRepository newhouseRepository)
        {
            this._cacheManager = cacheManagerProvider.GetDistrubuteCacheManager();
            this._newhouseRepository = newhouseRepository;
        }

        public async Task<NewhouseModel> GetAsync(int sid)
        {
            var keyPrefix = "NewhouseModel::";
            var key = keyPrefix + sid;
            var cache = this._cacheManager.Get<NewhouseModel>(key);
            if (cache != null)
            {
                return cache;
            }
            var houseModel = await this._newhouseRepository.GetAsync(sid);
            if (houseModel != null)
            {
                this._cacheManager.Save(key, houseModel);
            }

            return houseModel;
        }

        public async Task<IResult> InsertAsync(NewhouseModel newhouseModel)
        {
            return await this._newhouseRepository.InsertAsync(newhouseModel);
        }

        public async Task<IResult> UpdateAsync(NewhouseModel newhouseModel)
        {
            return await this._newhouseRepository.UpdateAsync(newhouseModel);
        }
    }
}