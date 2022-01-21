using Business.Entities;
using Business.Repositories.DataRepositories;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.DataRepositories
{
    public class UserRepository : AbstractRepository<User, int>, IUserRepository
	{
		public UserRepository(Context context)
		{
			_context = context;
		}

		#region implementation
		protected override int KeySelector(User entity) => entity.Id;

		protected override User ReadImplementation(int key)
		{
			return QueryImplementation().FirstOrDefault(i => i.Id == key);
		}



		protected override void CreateImplementation(User value)
		{
			_context.Users.Add(value);
		}



		protected override void UpdateImplementation(User value)
		{
			_context.Update(value);
		}

		protected override void DeleteImplementation(User value)
		{
			var entity = ReadImplementation(value.Id);
			if (entity == null) return;
			_context.Users.Remove(entity);
		}

		protected override IQueryable<User> QueryImplementation()
		{
			return _context.Users;
		}
		#endregion
	}

}
