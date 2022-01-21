using Business.Entities;
using Business.Repositories.DataRepositories;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.DataRepositories
{
    public class LotRepository : AbstractRepository<Lot, int>, ILotRepository
	{
		public LotRepository(Context context)
		{
			_context = context;
		}

		#region implementation
		protected override int KeySelector(Lot entity) => entity.Id;

		protected override Lot ReadImplementation(int key)
		{
			return QueryImplementation().FirstOrDefault(i => i.Id == key);
		}



		protected override void CreateImplementation(Lot value)
		{
			_context.Lots.Add(value);
		}



		protected override void UpdateImplementation(Lot value)
		{
			_context.Update(value);
		}

		protected override void DeleteImplementation(Lot value)
		{
			var entity = ReadImplementation(value.Id);
			if (entity == null) return;
			_context.Lots.Remove(entity);
		}

		protected override IQueryable<Lot> QueryImplementation()
		{
			return _context.Lots
				//.Include(r => r.Seller)
				//.Include(r => r.Byuer)
				.Include(r => r.Auction)
				.Include(r => r.AuctionItem);

		}
		#endregion
	}

}
