using AutoMapper;
using Business.Entities;
using Business.Interop.Data;
using Business.Repositories.DataRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class AuctionHouseService : IAuctionHouseService
    {
        private readonly IAuctionHouseRepository _auctionHouseRepository;
        private readonly IMapper _mapper;

        public AuctionHouseService(IAuctionHouseRepository repository, IMapper mapper)
        {
            _auctionHouseRepository = repository;
            _mapper = mapper;
        }

        public IEnumerable<AuctionHouseDto> GetAll()
        {
            var auctionHouses = _auctionHouseRepository.Query();

            return _mapper.Map<List<AuctionHouse>, IEnumerable<AuctionHouseDto>>(auctionHouses);
        }
    }
}
