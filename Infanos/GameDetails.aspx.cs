using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Infanos.Models;
using System.Web.ModelBinding;

namespace Infanos
{
    public partial class GameDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Games> GetGames(
                            [QueryString("GameID")] int? gameId,
                            [RouteData] string gameName)
        {
            var db = new Infanos.Models.Context();
            IQueryable<Games> query = db.Games;
            if (gameId.HasValue && gameId > 0)
            {
                query = query.Where(p => p.GameID == gameId);
            }
            else if (!String.IsNullOrEmpty(gameName))
            {
                query = query.Where(p =>
                          String.Compare(p.GameName, gameName) == 0);
            }
            else
            {
                query = null;
            }
            return query;
        }
    }
}