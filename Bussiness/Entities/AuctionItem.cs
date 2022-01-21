using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class AuctionItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ValPrice { get; set; }
        public State State { get; set; }
        public Epoch Epoch { get; set; }
        public Genre Genre { get; set; }
        public User Owner { get; set; }

        public int GenreId { get; set; }
        public int EpochId { get; set; }
        public int StateId { get; set; }
        public int OwnerId { get; set; }
        public DateTime? CreationDate { get; set; }
        public IEnumerable<Lot> Lots { get; set; }
    }
}
