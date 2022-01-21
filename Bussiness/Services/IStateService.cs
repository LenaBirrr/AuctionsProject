using Business.Interop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IStateService
    {
        public IEnumerable<StateDto> GetAll();
        public IEnumerable<StateDto> FindByName(string name);
        public StateDto GetById(int id);
    }
}
