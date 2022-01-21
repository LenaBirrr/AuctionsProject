using Business.Interop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface ILotService
    {
        public LotDto CreateLot(LotDto lot);
        public LotDto UpdateLot(LotDto lot);
        public void DeleteLot(int id);
        //???
        public IEnumerable<LotDto> GetAll();
        public LotDto GetById(int Id);
        public IEnumerable<LotDto> GetByBuyer(ParticipantDto buyer);
        public IEnumerable<LotDto> GetBySeller(ParticipantDto seller);
        public IEnumerable<LotDto> GetByAuction(int auctionId);
        
    }
}
