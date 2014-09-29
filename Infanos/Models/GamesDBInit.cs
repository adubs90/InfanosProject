using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace Infanos.Models
{
    public class GamesDBInit : DropCreateDatabaseIfModelChanges<Context>
    {

        protected override void Seed(Context context)
        {
            getConsoles().ForEach(c => context.Consoles.Add(c));
            getGames().ForEach(p => context.Games.Add(p));
        }

        private static List<Consoles> getConsoles()
        {
            var consoles = new List<Consoles>
            {
                new Consoles
                {
                    ConsoleID = 1,
                    ConsoleName = "NES"
                },
                 new Consoles
                {
                    ConsoleID = 2,
                    ConsoleName = "SNES"
                },
                 new Consoles
                {
                    ConsoleID = 3,
                    ConsoleName = "GBA"
                },
                 new Consoles
                {
                    ConsoleID = 4,
                    ConsoleName = "PSX"
                },
                 new Consoles
                {
                    ConsoleID = 5,
                    ConsoleName = "N64"
                },

            };

            return consoles;
        }


        private static List<Games> getGames()
        {
            var games = new List<Games>
            {
                new Games
                {
                    GameID = 1,
                    GameName = "Super Mario1",
                    Description = "It's the brothas, the brothas, THE BROTHAS!",
                    ImagePath = "nesGames.jpg",
                    GamePrice = 1.00,
                    ConsoleID = 1
                },

                 new Games
                {
                    GameID = 2,
                    GameName = "Super Mario2",
                    Description = "It's the brothas, the brothas, THE BROTHAS!",
                    ImagePath = "nesGames.jpg",
                    GamePrice = 2.00,
                    ConsoleID = 1
                },

                 new Games
                {
                    GameID = 3,
                    GameName = "Super Mario3",
                    Description = "It's the brothas, the brothas, THE BROTHAS!",
                    ImagePath = "nesGames.jpg",
                    GamePrice = 3.00,
                    ConsoleID = 1
                },

                 new Games
                {
                    GameID = 4,
                    GameName = "Super Mario4",
                    Description = "It's the brothas, the brothas, THE BROTHAS!",
                    ImagePath = "nesGames.jpg",
                    GamePrice = 4.00,
                    ConsoleID = 2
                },

                 new Games
                {
                    GameID = 5,
                    GameName = "Super Mario5",
                    Description = "It's the brothas, the brothas, THE BROTHAS!",
                    ImagePath = "nesGames.jpg",
                    GamePrice = 5.00,
                    ConsoleID = 2
                },

                 new Games
                {
                    GameID = 6,
                    GameName = "Super Mario6",
                    Description = "It's the brothas, the brothas, THE BROTHAS!",
                    ImagePath = "nesGames.jpg",
                    GamePrice = 6.00,
                    ConsoleID = 2
                },

                 new Games
                {
                    GameID = 7,
                    GameName = "Super Mario7",
                    Description = "It's the brothas, the brothas, THE BROTHAS!",
                    ImagePath = "nesGames.jpg",
                    GamePrice = 7.00,
                    ConsoleID = 3
                },

                 new Games
                {
                    GameID = 8,
                    GameName = "Super Mario8",
                    Description = "It's the brothas, the brothas, THE BROTHAS!",
                    ImagePath = "nesGames.jpg",
                    GamePrice = 8.00,
                    ConsoleID = 3
                },

                 new Games
                {
                    GameID = 9,
                    GameName = "Super Mario9",
                    Description = "It's the brothas, the brothas, THE BROTHAS!",
                    ImagePath = "nesGames.jpg",
                    GamePrice = 9.00,
                    ConsoleID = 3
                },

                 new Games
                {
                    GameID = 10,
                    GameName = "Super Mario10",
                    Description = "It's the brothas, the brothas, THE BROTHAS!",
                    ImagePath = "nesGames.jpg",
                    GamePrice = 10.00,
                    ConsoleID = 4
                },

                  new Games
                {
                    GameID = 11,
                    GameName = "Super Mario11",
                    Description = "It's the brothas, the brothas, THE BROTHAS!",
                    ImagePath = "nesGames.jpg",
                    GamePrice = 11.00,
                    ConsoleID = 4
                },

                  new Games
                {
                    GameID = 12,
                    GameName = "Super Mario12",
                    Description = "It's the brothas, the brothas, THE BROTHAS!",
                    ImagePath = "nesGames.jpg",
                    GamePrice = 12.00,
                    ConsoleID = 4
                },

                  new Games
                {
                    GameID = 13,
                    GameName = "Super Mario13",
                    Description = "It's the brothas, the brothas, THE BROTHAS!",
                    ImagePath = "nesGames.jpg",
                    GamePrice = 13.00,
                    ConsoleID = 5
                },

                  new Games
                {
                    GameID = 14,
                    GameName = "Super Mario14",
                    Description = "It's the brothas, the brothas, THE BROTHAS!",
                    ImagePath = "nesGames.jpg",
                    GamePrice = 14.00,
                    ConsoleID = 5
                },

                  new Games
                {
                    GameID = 15,
                    GameName = "Super Mario15",
                    Description = "It's the brothas, the brothas, THE BROTHAS!",
                    ImagePath = "nesGames.jpg",
                    GamePrice = 15.00,
                    ConsoleID = 5
                },


            };
            return games;
        }


    }
}