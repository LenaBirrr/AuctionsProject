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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _userRepository = repository;
            _mapper = mapper;
        }

        public UserDto CreateUser(UserDto user)
        {
            var entity = _mapper.Map<User>(user);
            _userRepository.CreateOrUpdate(entity);
            return _mapper.Map<UserDto>(entity);
        }

        public void DeleteUser(int id)
        {
            var entity = _userRepository.Query()
                        .Where(i => i.Id == id);
            _userRepository.Delete(entity);
        }

        public IEnumerable<UserDto> GetAll()
        {
            var addresses = _userRepository.Query();

            return _mapper.Map<List<User>, IEnumerable<UserDto>>(addresses);
        }

        public UserDto GetById(int Id)
        {
            User users = (_userRepository.Query()
                       .Where(i => i.Id == Id)).First();

            return _mapper.Map<User, UserDto>(users);
        }

        public IEnumerable<UserDto> GetByName(string Name)
        {
            var participants = _userRepository.Query()
               .Where(i => i.FullName == Name);

            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(participants);
        }

        public UserDto UpdateUser(UserDto user)
        {
            var entity = _mapper.Map<User>(user);
            _userRepository.CreateOrUpdate(entity);
            return _mapper.Map<UserDto>(entity);
        }
    }
}
