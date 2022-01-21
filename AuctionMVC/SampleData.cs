using Business.Entities;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionMVC
{
    public static class SampleData
    {
        public static void Initialize(Context context)
        {
            
            if (!context.AuctionHouses.Any())
            {
                context.AuctionHouses.AddRange(
                      new AuctionHouse
                      {
                          Name = "Christie's"
                      },

                      new AuctionHouse
                      {
                          Name = "Sotheby's"
                      },
                      new AuctionHouse
                      {
                          Name = "Phillips de Pury"
                      }
                      );
            }
            if (!context.Auctions.Any())
            {
                context.Auctions.AddRange(
                      new Auction
                      {
                          Date = Convert.ToDateTime("2021-12-11"),
                          Topic = "Живопись",
                          Address = "221 B Baker St, London, England",
                          AuctionHouseId = 1,
                      });
            }
            if (!context.States.Any())
            {
                context.States.AddRange(
                      new State
                      {
                          Name = "Идеальное"
                      },

                      new State
                      {
                          Name = "Отличное"
                      },
                      new State
                      {
                          Name = "Хорошее+"
                      },
                      new State
                      {
                          Name = "Хорошее"
                      },
                      new State
                      {
                          Name = "Хорошее-"
                      },
                      new State
                      {
                          Name = "Удовлетворительное"
                      },
                      new State
                      {
                          Name = "Плохое"
                      }
                      );
            }
            if (!context.Types.Any())
            {
                context.Types.AddRange(
                      new Business.Entities.Type
                      {
                          Name = "Пространственное"
                      },

                      new Business.Entities.Type
                      {
                          Name = "Временное"
                      },
                      new Business.Entities.Type
                      {
                          Name = "Пространственно-временное"
                      }
                      );
            }
            if (!context.Subtypes.Any())
            {
                context.Subtypes.AddRange(
                      new Subtype
                      {
                          Name = "Кино"
                      },

                      new Subtype
                      {
                          Name = "Живопись"
                      },
                      new Subtype
                      {
                          Name = "Литература"
                      }
                      );
            }
            if (!context.Genres.Any())
            {
                context.Genres.AddRange(
                      new Genre
                      {
                          Name = "Портрет",
                          SubtypeId = 2
                      },

                      new Genre
                      {
                          Name = "Роман",
                          SubtypeId = 3
                      },
                      new Genre
                      {
                          Name = "Ужасы",
                          SubtypeId = 1
                      }

                      ) ;
            }           
            if (!context.Epoches.Any())
            {
                context.Epoches.AddRange(
                      new Epoch
                      {
                          Name = "Древний мир"
                      },
                      new Epoch
                      {
                          Name = "Античность"
                      },

                      new Epoch
                      {
                          Name = "Средневековье"
                      },
                      new Epoch
                      {
                          Name = "Возрождение"
                      },
                       new Epoch
                       {
                           Name = "Барокко"
                       },
                        new Epoch
                        {
                            Name = "Классицизм"
                        },
                         new Epoch
                         {
                             Name = "Век просвещения"
                         },
                          new Epoch
                          {
                              Name = "Романтизм"
                          },
                           new Epoch
                           {
                               Name = "Реализм"
                           },
                            new Epoch
                            {
                                Name = "Модернизм"
                            },
                             new Epoch
                             {
                                 Name = "Постмодернизм"
                             },
                              new Epoch
                              {
                                  Name = "Метамодернизм"
                              }
                      );
            }
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                      new User
                      {
                          FullName = "Иванов Иван Иванович"
                      }
                      );
            }
            if (!context.Participants.Any())
            {
                context.Participants.AddRange(
                      new Participant
                      {
                          UserId = 1,
                          AuctionId=1

                      }
                      );
               
            }
            if (!context.AuctionItems.Any())
            {
                context.AuctionItems.AddRange(
                      new AuctionItem
                      {
                          OwnerId = 1,
                          EpochId = 1,
                          StateId=1,
                          GenreId=1,
                          CreationDate = Convert.ToDateTime("2001-12-11"),
                          ValPrice=10,
                          Name="Некоторая картина"
                      }
                      );

            }
            //items
            context.SaveChanges();
        }
    }
}

