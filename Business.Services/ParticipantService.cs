using AutoMapper;
using Business.Entities;
using Business.Interop.Data;
using Business.Repositories.DataRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ParticipantService : IParticipantService
    {
        private readonly IParticipantRepository _participantRepository;
        private readonly IMapper _mapper;

        public ParticipantService(IParticipantRepository repository, IMapper mapper)
        {
            _participantRepository = repository;
            _mapper = mapper;
        }
        public ParticipantDto CreateParticipant(ParticipantDto participant)
        {
            var entity = _mapper.Map<Participant>(participant);
            _participantRepository.CreateOrUpdate(entity);
            return _mapper.Map<ParticipantDto>(entity);
        }

        public void DeleteParticipant(int id)
        {
            var entity = _participantRepository.Query()
                         .Where(i => i.Id == id);
            _participantRepository.Delete(entity);
        }

        public IEnumerable<ParticipantDto> GetAll()
        {
            var participants = _participantRepository.Query();

            return _mapper.Map<List<Participant>, IEnumerable<ParticipantDto>>(participants);
        }

        public IEnumerable<ParticipantDto> GetByAuction(int auctionId)
        {
            var participants = _participantRepository.Query()
                                   .Where(i => i.Auction.Id == auctionId);

            return _mapper.Map<IEnumerable<Participant>, IEnumerable<ParticipantDto>>(participants);
        }

        public ParticipantDto GetById(int Id)
        {
            var participants = _participantRepository.Read(Id);

            return _mapper.Map<ParticipantDto>(participants);
        }

        public ParticipantDto UpdateParticipant(ParticipantDto participant)
        {
            var entity = _mapper.Map<Participant>(participant);
            _participantRepository.CreateOrUpdate(entity);
            return _mapper.Map<ParticipantDto>(entity);
        }
    }
}
