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
    public class StateRepository : AbstractRepository<State, int>, IStateRepository
	{
		public StateRepository(Context context)
		{
			_context = context;
		}

		#region implementation
		protected override int KeySelector(State entity) => entity.Id;

		protected override State ReadImplementation(int key)
		{
			return QueryImplementation().FirstOrDefault(i => i.Id == key);
		}



		protected override void CreateImplementation(State value)
		{
			_context.States.Add(value);
		}



		protected override void UpdateImplementation(State value)
		{
			_context.Update(value);
		}

		protected override void DeleteImplementation(State value)
		{
			var entity = ReadImplementation(value.Id);
			if (entity == null) return;
			_context.States.Remove(entity);
		}

		protected override IQueryable<State> QueryImplementation()
		{
			return _context.States;
		}
		#endregion
	}
}
