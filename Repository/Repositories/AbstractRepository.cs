using Business.Repositories;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public abstract class AbstractRepository<T, TKey> : IRepository<T, TKey> where T : class
	{
		private readonly object _syncRoot = new();
		protected Context _context;

		#region protected

		protected void CreateOrUpdateImplementation(T value)
		{
			var entity = ReadImplementation(KeySelector(value));
			if (entity == null) CreateImplementation(value);
			else
			{
				_context.Entry(entity).State = EntityState.Detached;
				UpdateImplementation(value);
			}
		}

		
		protected void OperationEnvironment(Action body)
		{
			lock (_syncRoot)
			{

				body.Invoke();
				try
				{
					_context.SaveChanges();
				}
				catch (DbUpdateConcurrencyException ex)
				{
					ex.Entries.Single().Reload();
					_context.SaveChanges();
				}

			}
		}

		protected TRet OperationEnvironment<TRet>(Func<TRet> body)
		{
			lock (_syncRoot)
			{
				return body.Invoke();
			}
		}

		

		public void UpdateFields(T value, params Expression<Func<T, object>>[] includeProperties)
		{
			OperationEnvironment(() =>
			{
				var dbEntry = _context.Entry(value);
				foreach (var includeProperty in includeProperties)
				{
					dbEntry.Property(includeProperty).IsModified = true;
				}
			});
		}

		#region abstract
		protected abstract TKey KeySelector(T value);

		protected abstract T ReadImplementation(TKey key);
		protected abstract void CreateImplementation(T value);
		protected abstract void UpdateImplementation(T value);
		protected abstract void DeleteImplementation(T value);

		protected abstract IQueryable<T> QueryImplementation();
		#endregion
		#endregion

		#region inteface
		public T Read(TKey key)
		{
			return OperationEnvironment(() => ReadImplementation(key));
		}

		
		public void Create(T value)
		{
			OperationEnvironment(() => CreateImplementation(value));
		}

		

		public void Update(T value)
		{
			OperationEnvironment(() => UpdateImplementation(value));
		}

		public void CreateOrUpdate(T value)
		{
			OperationEnvironment(() => CreateOrUpdateImplementation(value));
		}

		

		public void Delete(T value)
		{
			OperationEnvironment(() => DeleteImplementation(value));
		}

		public void Create(IEnumerable<T> values)
		{
			OperationEnvironment(() => values.ToList().ForEach(CreateImplementation));
		}

		

		public void Update(IEnumerable<T> values)
		{
			OperationEnvironment(() => values.ToList().ForEach(v => UpdateImplementation(v)));
		}

		public void CreateOrUpdate(IEnumerable<T> values)
		{
			OperationEnvironment(() => values.ToList().ForEach(CreateOrUpdateImplementation));
		}

		

		public void Delete(IEnumerable<T> values)
		{
			OperationEnvironment(() => values.ToList().ForEach(DeleteImplementation));
		}

		public List<T> Query(Expression<Func<T, bool>> where = null)
		{
			return OperationEnvironment(() =>
			{
				var query = QueryImplementation();
				if (where != null) query = query.Where(where);
				return query.ToList();
			});
		}

		

		public TResult Query<TResult>(Func<IQueryable<T>, TResult> body)
		{
			return OperationEnvironment(() =>
			{
				var query = QueryImplementation();
				return body(query);
			});
		}
		#endregion
	}
}

