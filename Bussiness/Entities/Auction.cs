using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Auction
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public DateTime Date { get; set; }
        public AuctionHouse AuctionHouse { get; set; }
        public int AuctionHouseId { get; set; }
        public string Address { get; set; }
        public IEnumerable<Lot> Lots { get; set; }
        public IEnumerable<Participant>Participants {get;set;}

    }
}
