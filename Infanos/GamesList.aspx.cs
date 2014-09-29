using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Infanos.Models;
using System.Web.ModelBinding;
using System.Web.Routing;

namespace Infanos
{
    public partial class GamesList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Games> GetGames(
                     [QueryString("id")] int? consoleId,
                     [RouteData] string consoleName)
        {
            var db = new Infanos.Models.Context();
            IQueryable<Games> query = db.Games;

            if (consoleId.HasValue && consoleId > 0)
            {
                query = query.Where(p => p.ConsoleID == consoleId);
            }

            if (!String.IsNullOrEmpty(consoleName))
            {
                query = query.Where(p =>
                                    String.Compare(p.Consoles.ConsoleName,
                                    consoleName) == 0);
            }
            return query;
        }
    }
}