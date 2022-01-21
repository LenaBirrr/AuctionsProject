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
    public class AuctionItemRepository : AbstractRepository<AuctionItem, int>, IAuctionItemRepository
	{
		public AuctionItemRepository(Context context)
		{
			_context = context;
		}

		#region implementation
		protected override int KeySelector(AuctionItem entity) => entity.Id;

		protected override AuctionItem ReadImplementation(int key)
		{
			return QueryImplementation().FirstOrDefault(i => i.Id == key);
		}



		protected override void CreateImplementation(AuctionItem value)
		{
			_context.AuctionItems.Add(value);
		}



		protected override void UpdateImplementation(AuctionItem value)
		{
			_context.Update(value);
		}

		protected override void DeleteImplementation(AuctionItem value)
		{
			var entity = ReadImplementation(value.Id);
			if (entity == null) return;
			_context.AuctionItems.Remove(entity);
		}

		protected override IQueryable<AuctionItem> QueryImplementation()
		{
			return _context.AuctionItems
				.Include(r => r.Lots)
				.Include(r => r.Epoch)
				.Include(r => r.Genre)
					.ThenInclude(i=>i.Subtype)
						.ThenInclude(q=>q.Type)
				.Include(r => r.State)
				.Include(r => r.Owner);

		}
		#endregion
	}


}

