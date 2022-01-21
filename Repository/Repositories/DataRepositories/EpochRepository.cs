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
    public class EpochRepository : AbstractRepository<Epoch, int>, IEpochRepository
	{
		public EpochRepository(Context context)
		{
			_context = context;
		}

		#region implementation
		protected override int KeySelector(Epoch entity) => entity.Id;

		protected override Epoch ReadImplementation(int key)
		{
			return QueryImplementation().FirstOrDefault(i => i.Id == key);
		}



		protected override void CreateImplementation(Epoch value)
		{
			_context.Epoches.Add(value);
		}



		protected override void UpdateImplementation(Epoch value)
		{
			_context.Update(value);
		}

		protected override void DeleteImplementation(Epoch value)
		{
			var entity = ReadImplementation(value.Id);
			if (entity == null) return;
			_context.Epoches.Remove(entity);
		}

		protected override IQueryable<Epoch> QueryImplementation()
		{
			return _context.Epoches;
		}
		#endregion
	}
}
