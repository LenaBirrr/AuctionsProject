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
    public class StateService : IStateService
    {
        private readonly IStateRepository _stateRepository;
        private readonly IMapper _mapper;

        public StateService(IStateRepository repository, IMapper mapper)
        {
            _stateRepository = repository;
            _mapper = mapper;
        }
        
        public IEnumerable<StateDto> FindByName(string name)
        {
            var states = _stateRepository.Query()
                           .Where(i => i.Name.Contains(name, System.StringComparison.InvariantCultureIgnoreCase));

            return _mapper.Map<IEnumerable<State>, IEnumerable<StateDto>>(states);
        }

        public IEnumerable<StateDto> GetAll()
        {
            var states = _stateRepository.Query();

            return _mapper.Map<List<State>, IEnumerable<StateDto>>(states);
        }

        public StateDto GetById(int id)
        {
            State st = (_stateRepository.Query()
                             .Where(i => i.Id == id)).First();

            return _mapper.Map<State, StateDto>(st);
        }
    }
}
