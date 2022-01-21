using Business.Interop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IAuctionService
    {
        public IEnumerable<AuctionDto> GetAll();
        public AuctionDto CreateAuction(AuctionDto auction);
        public AuctionDto UpdateAuction(AuctionDto auction);
        public void DeleteAuction(int id);
        //???
        public AuctionDto GetById(int Id);
        public IEnumerable<AuctionDto> GetByDate(DateTime date);
    }
}
