using Business.Entities;
using Microsoft.EntityFrameworkCore;
using System;

using System.Linq;

namespace Repository.Data
{
    public class Context : DbContext
    {
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<AuctionHouse> AuctionHouses { get; set; }
        public DbSet<AuctionItem> AuctionItems { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Business.Entities.Type> Types { get; set; }
        public DbSet<Epoch> Epoches { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Lot> Lots { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Subtype> Subtypes { get; set; }

        public Context(DbContextOptions<Context> options) : base(options) {Database.EnsureCreated(); }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            foreach(var relashionship in modelBuilder.Model
                .GetEntityTypes()
                .Where(e=>!e.IsOwned())
                .SelectMany(e=>e.GetForeignKeys()))
                
            {
                relashionship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<AuctionHouse>().HasData
            (
            new AuctionHouse
            {
                Id=1,
                Name = "Christie's"
            },
            new AuctionHouse
            {
                Id = 2,
                Name = "Sotheby's"
            },
            new AuctionHouse
            {
                Id = 3,
                Name = "Phillips de Pury"
            }
            );

            modelBuilder.Entity<Epoch>().HasData
            (
            new Epoch
            {
                Id=1,
                Name = "Древний мир"
            },
            new Epoch
            {
                Id=2,
                Name = "Античность"
            },
            new Epoch
            {
                Id=3,
                Name = "Средневековье"
            },
            new Epoch
            {
                Id=4,
                Name = "Возрождение"
            },
            new Epoch
            {
                Id=5,
                Name = "Барокко"
            },
            new Epoch
            {
                Id=6,
                Name = "Классицизм"
            },
            new Epoch
            {
                Id=7,
                Name = "Век просвещения"
            },
            new Epoch
            {
                Id=8,
                Name = "Романтизм"
            },
            new Epoch
            {
                Id=9,
                Name = "Реализм"
            },
            new Epoch
            {
                Id=10,
                Name = "Модернизм"
            },
            new Epoch
            {
                Id=11,
                Name = "Постмодернизм"
            }
            );

            modelBuilder.Entity<State>().HasData
            (
             new State
             {
                 Id=1,
                 Name = "Идеальное"
             },
             new State
             {
                 Id=2,
                 Name = "Отличное"
             },
             new State
             {
                 Id=3,
                 Name = "Хорошее+"
             },
             new State
             {
                 Id=4,
                 Name = "Хорошее"
             },
             new State
             {
                 Id=5,
                 Name = "Хорошее-"
             },
             new State
             {
                 Id=6,
                 Name = "Удовлетворительное"
             },
             new State
             {
                 Id=7,
                 Name = "Плохое"
             }
             );

            modelBuilder.Entity<Auction>().HasData
            (
            new Auction
            {
                Id=1,
                Date = Convert.ToDateTime("2021-12-11"),
                Topic = "Живопись",
                Address = "221 B Baker St, London, England",
                AuctionHouseId = 1,
            });
            
            modelBuilder.Entity<Business.Entities.Type>().HasData
                (
                new Business.Entities.Type
                {
                    Id=1,
                    Name = "Пространственное"
                },
                new Business.Entities.Type
                {
                    Id=2,
                    Name = "Временное"
                },
                new Business.Entities.Type
                {
                    Id=3,
                    Name = "Пространственно-временное"
                }
                );

            modelBuilder.Entity<Subtype>().HasData
                (
                new Subtype
                {
                    Id=1,
                    TypeId=3,
                    Name = "Кино"
                },
                new Subtype
                {
                    Id=2,
                    TypeId=1,
                    Name = "Живопись"
                },
                new Subtype
                {
                    Id=3,
                    TypeId=2,
                    Name = "Литература"
                }
                );

            modelBuilder.Entity<Genre>().HasData
            (
                new Genre
                {
                    Id = 1,
                    Name = "Портрет",
                    SubtypeId = 2
                },
                new Genre
                {
                    Id=2,
                    Name = "Роман",
                    SubtypeId = 3
                },
                new Genre
                {
                    Id=3,
                    Name = "Ужасы",
                    SubtypeId = 1
                }
             );

            modelBuilder.Entity<User>().HasData
            (
                 new User
                 {
                     Id=1,
                     FullName = "Иванов Иван Иванович"
                 },
                 new User
                 {
                     Id = 2,
                     FullName = "Петров Петр Петрович"
                 }
            );

            modelBuilder.Entity<Participant>().HasData
                (
                    new Participant
                    {
                        Id = 1,
                        UserId = 1,
                        AuctionId = 1
                    },
                    new Participant
                    {
                        Id = 2,
                        UserId = 2,
                        AuctionId = 1
                    }
                );

            modelBuilder.Entity<AuctionItem>().HasData
                (
                new AuctionItem
                {
                    Id = 1,
                    CreationDate = Convert.ToDateTime("2001-12-10"),
                    GenreId = 1,
                    EpochId = 1,
                    StateId = 1,
                    OwnerId = 1,
                    ValPrice = 50,
                    Name = "Предмет"
                }
                );

            modelBuilder.Entity<Lot>().HasData
                (
                new Lot
                {
                    Id=1,
                    Price=100,
                    AuctionId=1,
                    AuctionItemId=1,
                    ByuerId=1,
                    SellerId=2,
                }
                );
            base.OnModelCreating(modelBuilder);

		}

    }
}
