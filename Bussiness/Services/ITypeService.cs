using Business.Interop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface ITypeService
    {
        public IEnumerable<TypeDto> GetAll();

    }
}
