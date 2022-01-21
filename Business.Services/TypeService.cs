using AutoMapper;
using Business.Interop.Data;
using Business.Repositories.DataRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class TypeService : ITypeService
    {
        private readonly ITypeRepository _typeRepository;
        private readonly IMapper _mapper;

        public IEnumerable<TypeDto> GetAll()
        {
            var types = _typeRepository.Query();

            return _mapper.Map<List<Entities.Type>, IEnumerable<TypeDto>>(types);
        }
    }
}
