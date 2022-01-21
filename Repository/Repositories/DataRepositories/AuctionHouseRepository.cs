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
    public class AuctionHouseRepository : AbstractRepository<AuctionHouse, int>, IAuctionHouseRepository
	{
		public AuctionHouseRepository(Context context)
		{
			_context = context;
		}

	#region implementation
		protected override int KeySelector(AuctionHouse entity) => entity.Id;

		protected override AuctionHouse ReadImplementation(int key)
		{
			return QueryImplementation().FirstOrDefault(i => i.Id == key);
		}



		protected override void CreateImplementation(AuctionHouse value)
		{
			_context.AuctionHouses.Add(value);
		}



		protected override void UpdateImplementation(AuctionHouse value)
		{
			_context.Update(value);
		}

		protected override void DeleteImplementation(AuctionHouse value)
		{
			var entity = ReadImplementation(value.Id);
			if (entity == null) return;
			_context.AuctionHouses.Remove(entity);
		}

		protected override IQueryable<AuctionHouse> QueryImplementation()
		{
			return _context.AuctionHouses;
		}
	#endregion
	}

}

