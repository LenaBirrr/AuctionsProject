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
    public class EpochService : IEpochService
    {
        private readonly IEpochRepository _epochRepository;
        private readonly IMapper _mapper;

        public EpochService(IEpochRepository repository, IMapper mapper)
        {
            _epochRepository = repository;
            _mapper = mapper;
        }

        public IEnumerable<EpochDto> FindByName(string name)
        {
            var epoches = _epochRepository.Query()
                            .Where(i => i.Name.Contains(name, System.StringComparison.InvariantCultureIgnoreCase));

            return _mapper.Map<IEnumerable<Epoch>, IEnumerable<EpochDto>>(epoches);
        }

        public IEnumerable<EpochDto> GetAll()
        {
            var epoches = _epochRepository.Query();

            return _mapper.Map<List<Epoch>, IEnumerable<EpochDto>>(epoches);
        }

        public EpochDto GetById(int id)
        {
            Epoch epoch = _epochRepository.Read(id);

            return _mapper.Map<Epoch, EpochDto>(epoch);
        }
    }
}
