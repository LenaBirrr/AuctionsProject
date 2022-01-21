using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interop.Data
{
    public class SubtypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TypeDto Type { get; set; }
            
    }
}
