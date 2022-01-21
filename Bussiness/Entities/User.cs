using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public IEnumerable<Participant> Participants { get; set; }
    }
}
