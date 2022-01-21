using Business.Interop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IEpochService
    {
        public IEnumerable<EpochDto> GetAll();
        public IEnumerable<EpochDto> FindByName(string name);
        public EpochDto GetById(int id);
    }
}
