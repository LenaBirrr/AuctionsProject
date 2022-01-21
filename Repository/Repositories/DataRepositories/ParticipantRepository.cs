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
    public class ParticipantRepository : AbstractRepository<Participant, int>, IParticipantRepository
	{
		public ParticipantRepository(Context context)
		{
			_context = context;
		}

		#region implementation
		protected override int KeySelector(Participant entity) => entity.Id;

		protected override Participant ReadImplementation(int key)
		{
			return QueryImplementation().FirstOrDefault(i => i.Id == key);
		}



		protected override void CreateImplementation(Participant value)
		{
			_context.Participants.Add(value);
		}



		protected override void UpdateImplementation(Participant value)
		{
			_context.Update(value);
		}

		protected override void DeleteImplementation(Participant value)
		{
			var entity = ReadImplementation(value.Id);
			if (entity == null) return;
			_context.Participants.Remove(entity);
		}

		protected override IQueryable<Participant> QueryImplementation()
		{
			return _context.Participants
				.Include(r => r.User);
				//.Include(r => r.Auction);
							
		}
		#endregion
	}

}
