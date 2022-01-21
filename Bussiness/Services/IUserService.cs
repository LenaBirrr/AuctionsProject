using Business.Interop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IUserService
    {
        public IEnumerable<UserDto> GetAll();
        public UserDto CreateUser(UserDto auction);
        public UserDto UpdateUser(UserDto auction);
        public void DeleteUser(int id);
        public UserDto GetById(int Id);
        public IEnumerable<UserDto> GetByName(string Name);


    }
}
