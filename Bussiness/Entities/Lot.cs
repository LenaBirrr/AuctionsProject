using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Lot
    {
        public int Id { get; set; }
        public int? Price { get; set; }
        public Auction Auction { get; set; }
        public int AuctionId { get; set; }
        public Participant Seller { get; set; }
        public int AuctionItemId { get; set; }
        public int SellerId { get; set; }
        public int ByuerId { get; set; }

        public Participant Byuer { get; set; }
        public AuctionItem AuctionItem { get; set; }
    }
}
