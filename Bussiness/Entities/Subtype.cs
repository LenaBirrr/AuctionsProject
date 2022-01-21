using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Subtype
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Entities.Type Type {get;set;}
        public int TypeId { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}
