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
    public class LotService : ILotService
    {
        private readonly ILotRepository _lotRepository;
        private readonly IMapper _mapper;

        public LotService(ILotRepository repository, IMapper mapper)
        {
            _lotRepository = repository;
            _mapper = mapper;
        }

        public LotDto CreateLot(LotDto lot)
        {
            var entity = _mapper.Map<Lot>(lot);
            _lotRepository.CreateOrUpdate(entity);
            return _mapper.Map<LotDto>(entity);
        }

        public void DeleteLot(int id)
        {
            var entity = _lotRepository.Query()
                         .Where(i => i.Id == id);
            _lotRepository.Delete(entity);
        }

       
        public IEnumerable<LotDto> GetByAuction(int auctionId)
        {
            var lots = _lotRepository.Query()
                       .Where(i => i.Auction.Id == auctionId);

            return _mapper.Map<IEnumerable<Lot>, IEnumerable<LotDto>>(lots);
        }

        public IEnumerable<LotDto> GetByBuyer(ParticipantDto buyer)
        {
            var lots = _lotRepository.Query()
                       .Where(i => i.Byuer.Id == buyer.Id);

            return _mapper.Map<IEnumerable<Lot>, IEnumerable<LotDto>>(lots);
        }

        public LotDto GetById(int Id)
        {
            var lots = _lotRepository.Read(Id);

            return _mapper.Map<LotDto>(lots);
        }

        public IEnumerable<LotDto> GetBySeller(ParticipantDto seller)
        {
            var lots = _lotRepository.Query()
                       .Where(i => i.Byuer.Id == seller.Id);

            return _mapper.Map<IEnumerable<Lot>, IEnumerable<LotDto>>(lots);
        }

        public LotDto UpdateLot(LotDto lot)
        {
            var entity = _mapper.Map<Lot>(lot);
            _lotRepository.CreateOrUpdate(entity);
            return _mapper.Map<LotDto>(entity);
        }

        IEnumerable<LotDto> ILotService.GetAll()
        {
            var lots = _lotRepository.Query();

            return _mapper.Map<List<Lot>, IEnumerable<LotDto>>(lots);
        }
    }
}
