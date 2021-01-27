using AutoMapper;
using NewHouse.Common.Extension;
using NewHouse.Repository.Interface;
using NewHouse.Service.Dtos;
using NewHouse.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHouse.Service.Implement
{
    public class CountyDistrictService : ICountyDistrictService
    {
        private readonly IMapper _mapper;

        private readonly IDistirctRepository _distirctRepository;

        public CountyDistrictService(IMapper mapper, IDistirctRepository distirctRepository)
        {
            this._mapper = mapper;
            this._distirctRepository = distirctRepository;
        }

        private async Task<IEnumerable<DistrictDto>> GetAllDisctircAsync()
        {
            var models = await this._distirctRepository.GetAllAsync();

            return this._mapper.Map<List<DistrictDto>>(models);
        }

        public async Task<string> GetCountyName(string address)
        {
            if (address.IsNullOrEmpty())
            {
                return "";
            }

            var allDisctrict = await this.GetAllDisctircAsync();

            var allCounty = allDisctrict.GroupBy(x => x.CountyName)
                .Select(x => x.Key)
                .ToList();

            foreach (var county in allCounty)
            {
                if (address.Contains(county))
                {
                    return county;
                }
            }

            return "";
        }

        public async Task<string> GetDistrictName(string address)
        {
            if (address.IsNullOrEmpty())
            {
                return "";
            }

            var countyName = await this.GetCountyName(address);

            var allDistrict = await this.GetAllDisctircAsync();

            foreach (var district in allDistrict)
            {
                if (district.CountyName == countyName &&
                    address.Contains(district.DistrictName))
                {
                    return district.DistrictName;
                }
            }

            return "";
        }
    }
}