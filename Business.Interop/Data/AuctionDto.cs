using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interop.Data
{
    public class AuctionDto
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public DateTime Date { get; set; }
        public AuctionHouseDto AuctionHouse { get; set; }
        public int AuctionHouseId { get; set; }
        public string Address { get; set; }
        public IEnumerable<LotDto> Lots { get; set; }
        public IEnumerable<ParticipantDto> Participants { get; set; }
    }
}
