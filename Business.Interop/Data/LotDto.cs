using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interop.Data
{
    public class LotDto
    {
        public int Id { get; set; }
        [Min(1)]
        public int Price { get; set; }
        public AuctionDto Auction { get; set; }
        public int AuctionId { get; set; }
        public ParticipantDto Seller { get; set; }
        public int SellerId { get; set; }
        public ParticipantDto Byuer { get; set; }
        public int ByuerId { get; set; }
        public AuctionItemDto AuctionItem { get; set; }
        public int AuctionItemId { get; set; }

    }
}
