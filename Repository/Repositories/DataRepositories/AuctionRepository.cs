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
    public class AuctionRepository : AbstractRepository<Auction, int>, IAuctionRepository
	{
		public AuctionRepository(Context context)
		{
			_context = context;
		}

		#region implementation
		protected override int KeySelector(Auction entity) => entity.Id;

		protected override Auction ReadImplementation(int key)
		{
			return QueryImplementation().FirstOrDefault(i => i.Id == key);
		}

		

		protected override void CreateImplementation(Auction value)
		{
			_context.Auctions.Add(value);
		}

		

		protected override void UpdateImplementation(Auction value)
		{
			_context.Update(value);
		}

		protected override void DeleteImplementation(Auction value)
		{
			var entity = ReadImplementation(value.Id);
			if (entity == null) return;
			_context.Auctions.Remove(entity);
		}

		protected override IQueryable<Auction> QueryImplementation()
		{
			return _context.Auctions
				.Include(r => r.AuctionHouse)
				.Include(r=>r.Lots);
		}
		#endregion
	}
    
    
}
