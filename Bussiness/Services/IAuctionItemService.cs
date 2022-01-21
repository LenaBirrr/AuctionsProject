using Business.Interop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IAuctionItemService
    {
        public AuctionItemDto CreateAuctionItem(AuctionItemDto auctionItem);
        public AuctionItemDto UpdateAuctionItem(AuctionItemDto auctionItem);
        public void DeleteAuctionItem(int id);
        //???
        public AuctionItemDto GetById(int Id);
        public IEnumerable<AuctionItemDto> GetByOwner(UserDto owner);
        public IEnumerable<AuctionItemDto> GetAll();
        public IEnumerable<AuctionItemDto> GetByState(StateDto state);
        public IEnumerable<AuctionItemDto> GetByEpoch(EpochDto epoch);
        public IEnumerable<AuctionItemDto> GetByType(TypeDto type);
        public IEnumerable<AuctionItemDto> GetByGenre(GenreDto direction);
        public IEnumerable<AuctionItemDto> GetBySubtype(SubtypeDto genre);

    }
}
