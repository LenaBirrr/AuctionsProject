using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interop.Data
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public IEnumerable<ParticipantDto> Participants { get; set; }
    }
}
