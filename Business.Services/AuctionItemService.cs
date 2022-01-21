using AutoMapper;
using Business.Entities;
using Business.Interop.Data;
using Business.Repositories.DataRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
	public class AuctionItemService : IAuctionItemService
	{
		private readonly IAuctionItemRepository _auctionItemRepository;
		private readonly IEpochService _epochService;
		private readonly IStateService _stateService;
		private readonly IUserService _userService;
		private readonly IGenreService _genreService;

		private readonly IMapper _mapper;

		public AuctionItemService(IAuctionItemRepository repository,
			IEpochService epochService, 
			IStateService stateService,
			IUserService userService, 
			IGenreService genreService,
			IMapper mapper)
		{
			_auctionItemRepository = repository;
			_mapper = mapper;
			_epochService = epochService;
			_stateService = stateService;
			_userService = userService;
			_genreService = genreService;
		}

		public AuctionItemDto CreateAuctionItem(AuctionItemDto auctionItem)
		{
			var entity = _mapper.Map<AuctionItem>(auctionItem);
			
			_auctionItemRepository.CreateOrUpdate(entity);
			return _mapper.Map<AuctionItemDto>(entity);
		}

		public IEnumerable<AuctionItemDto> GetAll()
		{
			var auctionItems = _auctionItemRepository.Query();

			return _mapper.Map<List<AuctionItem>, IEnumerable<AuctionItemDto>>(auctionItems);
		}


		public AuctionItemDto UpdateAuctionItem(AuctionItemDto auctionItem)
		{
			var entity = _mapper.Map<AuctionItem>(auctionItem);
			_auctionItemRepository.CreateOrUpdate(entity);
			return _mapper.Map<AuctionItemDto>(entity);
		}

		public void DeleteAuctionItem(int id)
		{
			var entity = _auctionItemRepository.Query()
							.Where(i => i.Id == id);
			_auctionItemRepository.Delete(entity);
		}

		public AuctionItemDto GetById(int Id)
		{
			var auctionItem = _auctionItemRepository.Read(Id);

			return _mapper.Map<AuctionItemDto>(auctionItem);
		}

     

        public IEnumerable<AuctionItemDto> GetByOwner(UserDto owner)
        {
			var auctionItems = _auctionItemRepository.Query()
								.Where(i => i.Owner.Id == owner.Id);

			return _mapper.Map<IEnumerable<AuctionItem>, IEnumerable<AuctionItemDto>>(auctionItems);
		}

        public IEnumerable<AuctionItemDto> GetByState(StateDto state)
        {
			var auctionItems = _auctionItemRepository.Query()
								.Where(i => i.State.Id == state.Id);

			return _mapper.Map<IEnumerable<AuctionItem>, IEnumerable<AuctionItemDto>>(auctionItems);
		}

        public IEnumerable<AuctionItemDto> GetByEpoch(EpochDto epoch)
        {
			var auctionItems = _auctionItemRepository.Query()
								.Where(i => i.Epoch.Id == epoch.Id);

			return _mapper.Map<IEnumerable<AuctionItem>, IEnumerable<AuctionItemDto>>(auctionItems);
		}

        public IEnumerable<AuctionItemDto> GetByType(TypeDto type)
        {
			var auctionItems = _auctionItemRepository.Query().
								Where(i => i.Genre.Subtype.Type.Id == type.Id);

			return _mapper.Map<IEnumerable<AuctionItem>, IEnumerable<AuctionItemDto>>(auctionItems);
		}

        public IEnumerable<AuctionItemDto> GetByGenre(GenreDto genre)
        {
			var auctionItems = _auctionItemRepository.Query()
											.Where(i => i.Genre.Id == genre.Id);

			return _mapper.Map<IEnumerable<AuctionItem>, IEnumerable<AuctionItemDto>>(auctionItems);
		}

        public IEnumerable<AuctionItemDto> GetBySubtype(SubtypeDto subtype)
        {
			var auctionItems = _auctionItemRepository.Query()
														.Where(i => i.Genre.Subtype.Id == subtype.Id);

			return _mapper.Map<IEnumerable<AuctionItem>, IEnumerable<AuctionItemDto>>(auctionItems);
		}

        /*public IEnumerable<AuctionItemDto> GetAll()
        {
			var auctionItems = _auctionItemRepository.Query();

			return _mapper.Map<List<AuctionItem>, IEnumerable<AuctionItemDto>>(auctionItems);
		}*/
    }
}
