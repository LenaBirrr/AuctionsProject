using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Subtype Subtype { get; set; }
        public int SubtypeId { get; set; }
    }
}
