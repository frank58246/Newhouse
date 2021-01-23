using AutoMapper;
using NewHouse.Repository.Interface;
using NewHouse.Service.Dtos;
using NewHouse.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewHouse.Service.Implement
{
    public class NewhouseService : INewhouseService
    {
        private readonly INewhouseRepository _newhouseRepository;

        private readonly IMapper _mapper;

        public NewhouseService(IMapper mapper,
            INewhouseRepository newhouseRepository)
        {
            this._mapper = mapper;
            this._newhouseRepository = newhouseRepository;
        }

        public async Task<NewhouseDto> GetAsync(int sid)
        {
            if (sid == 0)
            {
                throw new ArgumentNullException(nameof(sid));
            }
            var newhouseModel = await this._newhouseRepository.GetAsync(sid);

            return this._mapper.Map<NewhouseDto>(newhouseModel);
        }
    }
}