using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Business.Repositories.DataRepositories;
using Repository.Data;

namespace Repository.Repositories.DataRepositories
{
    public class TypeRepository : AbstractRepository<Business.Entities.Type, int>, ITypeRepository
	{
		public TypeRepository(Context context)
		{
			_context = context;
		}

		#region implementation
		protected override int KeySelector(Business.Entities.Type entity) => entity.Id;

		protected override Business.Entities.Type ReadImplementation(int key)
		{
			return QueryImplementation().FirstOrDefault(i => i.Id == key);
		}



		protected override void CreateImplementation(Business.Entities.Type value)
		{
			_context.Types.Add(value);
		}



		protected override void UpdateImplementation(Business.Entities.Type value)
		{
			_context.Update(value);
		}

		protected override void DeleteImplementation(Business.Entities.Type value)
		{
			var entity = ReadImplementation(value.Id);
			if (entity == null) return;
			_context.Types.Remove(entity);
		}

		protected override IQueryable<Business.Entities.Type> QueryImplementation()
		{
			return _context.Types;
		}
		#endregion
	}
}
