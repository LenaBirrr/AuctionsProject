using Business.Interop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IGenreService
    {
        public IEnumerable<GenreDto> GetAll();
        public IEnumerable<GenreDto> FindByName(string name);
        public GenreDto GetById(int id);

    }
}
