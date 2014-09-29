using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Infanos.Models;

namespace Infanos.Logic
{
    public class AddGames
    {
        public bool GameAddToList(string GameName, string GameDesc, string GamePrice, string GameConsole, string GameImagePath)
        {
            var mygame= new Games();
            mygame.GameName = GameName;
            mygame.Description = GameDesc;
            mygame.GamePrice = Convert.ToDouble(GamePrice);
            mygame.ImagePath = GameImagePath;
            mygame.ConsoleID = Convert.ToInt32(GameConsole);

            using (Context db = new Context())
            {
                // Add product to DB.
                db.Games.Add(mygame);
                db.SaveChanges();
            }
            // Success.
            return true;
        }
    }
}