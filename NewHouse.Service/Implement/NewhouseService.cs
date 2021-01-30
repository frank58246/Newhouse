using AutoMapper;
using NewHouse.Common.Model;
using NewHouse.Repository.Interface;
using NewHouse.Repository.Model;
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

        public async Task<NewhouseDto> GetAsync(int hid)
        {
            if (hid == 0)
            {
                throw new ArgumentNullException(nameof(hid));
            }
            var newhouseModel = await this._newhouseRepository.GetAsync(hid);

            return this._mapper.Map<NewhouseDto>(newhouseModel);
        }

        public async Task<IResult> InsertAsync(NewhouseDto newhouseDto)
        {
            var newhouseModel = this._mapper.Map<NewhouseModel>(newhouseDto);

            newhouseModel.UpdateTime = DateTime.Now;

            return await this._newhouseRepository.InsertAsync(newhouseModel);
        }
    }
}