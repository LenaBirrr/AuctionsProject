using Business.Interop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IParticipantService
    {
        public ParticipantDto CreateParticipant(ParticipantDto participant);
        public ParticipantDto UpdateParticipant(ParticipantDto participant);
        public void DeleteParticipant(int id);
        public ParticipantDto GetById(int Id);
        public IEnumerable<ParticipantDto> GetByAuction(int auctionId);
        public IEnumerable<ParticipantDto> GetAll();
    }
}
