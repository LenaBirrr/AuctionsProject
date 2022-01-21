using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interop.Data
{
    public class AuctionItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Min(1)]
        public int ValPrice { get; set; }
        public StateDto State { get; set; }
        public EpochDto Epoch { get; set; }
        public GenreDto Genre { get; set; }
        public int GenreId { get; set; }
        public int EpochId { get; set; }
        public int StateId { get; set; }
        public int OwnerId { get; set; }

        public UserDto Owner { get; set; }
        public DateTime CreationDate { get; set; }
        public IEnumerable<LotDto> Lots { get; set; }
    }
}
