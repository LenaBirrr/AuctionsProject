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
    public class SubtypeRepository : AbstractRepository<Subtype, int>, ISubtypeRepository
	{
		public SubtypeRepository(Context context)
		{
			_context = context;
		}

		#region implementation
		protected override int KeySelector(Subtype entity) => entity.Id;

		protected override Subtype ReadImplementation(int key)
		{
			return QueryImplementation().FirstOrDefault(i => i.Id == key);
		}



		protected override void CreateImplementation(Subtype value)
		{
			_context.Subtypes.Add(value);
		}



		protected override void UpdateImplementation(Subtype value)
		{
			_context.Update(value);
		}

		protected override void DeleteImplementation(Subtype value)
		{
			var entity = ReadImplementation(value.Id);
			if (entity == null) return;
			_context.Subtypes.Remove(entity);
		}

		protected override IQueryable<Subtype> QueryImplementation()
		{
			return _context.Subtypes;
		}
		#endregion
	}

}
