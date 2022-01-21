using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interop.Data
{
    public class ParticipantDto
    {
        public int Id { get; set; }
        public AuctionDto Auction { get; set; }
        public int AuctionId { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }
    }
}
