using AutoMapper;
using Business.Entities;
using Business.Interop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ServiceMappingProfile: Profile
	{
		public ServiceMappingProfile()
		{
			// from entity to dto
			CreateMap<Auction, AuctionDto>();
			CreateMap<AuctionHouse, AuctionHouseDto>();
			CreateMap<AuctionItem, AuctionItemDto>();
			CreateMap<Genre, GenreDto>();
			CreateMap<Epoch, EpochDto>();
			CreateMap<Subtype, SubtypeDto>();
			CreateMap<Lot, LotDto>();
			CreateMap<Participant, ParticipantDto>();
			CreateMap<State, StateDto>();
			CreateMap<Entities.Type, TypeDto>();
			CreateMap<User, UserDto>();



			// from dto to entity
			CreateMap<AuctionDto, Auction>();
			CreateMap<AuctionHouseDto, AuctionHouse>();
			CreateMap<AuctionItemDto, AuctionItem>();
			CreateMap<GenreDto, Genre>();
			CreateMap<EpochDto, Epoch>();
			CreateMap<SubtypeDto, Subtype>();
			CreateMap<LotDto, Lot>();
			CreateMap<ParticipantDto, Participant>();
			CreateMap<StateDto, State>();
			CreateMap<TypeDto, Entities.Type>();
			CreateMap<UserDto, User>();
		}
	}
}
