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
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _directionRepository;
        private readonly IMapper _mapper;
        
        public GenreService(IGenreRepository repository, IMapper mapper)
        {
            _directionRepository = repository;
            _mapper = mapper;
        }

        public IEnumerable<GenreDto> FindByName(string name)
        {
            var genres = _directionRepository.Query()
                .Where(i => i.Name.Contains(name, System.StringComparison.InvariantCultureIgnoreCase));

            return _mapper.Map<IEnumerable<Genre>, IEnumerable<GenreDto>>(genres);
        }

        public IEnumerable<GenreDto> GetAll()
        {
            var directions = _directionRepository.Query();

            return _mapper.Map<List<Genre>, IEnumerable<GenreDto>>(directions);
        }

        public GenreDto GetById(int id)
        {
            Genre genre = (_directionRepository.Query()
                                               .Where(i => i.Id == id)).First();

            return _mapper.Map<Genre, GenreDto>(genre);
        }
    }
}
