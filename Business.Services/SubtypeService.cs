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
    public class SubtypeService : ISubtypeService
    {
        private readonly ISubtypeRepository _genreRepository;
        private readonly IMapper _mapper;

        public IEnumerable<SubtypeDto> GetAll()
        {
            var genres = _genreRepository.Query();

            return _mapper.Map<List<Subtype>, IEnumerable<SubtypeDto>>(genres);
        }
    }
}
