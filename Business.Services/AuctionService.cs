using Business.Entities;
using Business.Interop.Data;
using Business.Repositories.DataRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.Linq.Expressions;

namespace Business.Services
{
    public class AuctionService : IAuctionService
	{
		private readonly IAuctionRepository _auctionRepository;
		private readonly IMapper _mapper;

		public AuctionService(IAuctionRepository repository, IMapper mapper)
		{
			_auctionRepository = repository;
			_mapper = mapper;
		}

		

		public AuctionDto CreateAuction(AuctionDto auction)
		{
			var entity = _mapper.Map<Auction>(auction);
			_auctionRepository.CreateOrUpdate(entity);
			return _mapper.Map<AuctionDto>(entity);
		}

		public IEnumerable<AuctionDto> GetAll()
		{
			var auctions = _auctionRepository.Query();

			return _mapper.Map<List<Auction>, IEnumerable<AuctionDto>>(auctions);
		}


        public AuctionDto UpdateAuction(AuctionDto auction)
        {
			var entity = _mapper.Map<Auction>(auction);
			_auctionRepository.CreateOrUpdate(entity);
			return _mapper.Map<AuctionDto>(entity);
		}

        public void DeleteAuction(int id)
        {
			var entity = _auctionRepository.Query()
							.Where(i => i.Id == id);
			_auctionRepository.Delete(entity);
		}

        public AuctionDto GetById(int Id)
        {
			Auction auction = _auctionRepository.Read(Id);

			return _mapper.Map<AuctionDto>(auction);
		}

        public IEnumerable<AuctionDto> GetByDate(DateTime date)
        {
			var auctions = _auctionRepository.Query()
					.Where(i => i.Date==date);

			return _mapper.Map<IEnumerable<Auction>, IEnumerable<AuctionDto>>(auctions);
		}
    }
}
