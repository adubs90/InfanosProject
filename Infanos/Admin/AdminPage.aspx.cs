using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Infanos.Models;
using Infanos.Logic;

namespace Infanos.Admin
{
    public partial class AdminPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string productAction = Request.QueryString["ProductAction"];
            if (productAction == "add")
            {
                LabelAddStatus.Text = "Product added!";
            }

            if (productAction == "remove")
            {
                LabelRemoveStatus.Text = "Product removed!";
            }
        }

        protected void AddProductButton_Click(object sender, EventArgs e)
        {
            Boolean fileOK = false;
            String path = Server.MapPath("~/Catalog/Images/");
            if (GameImage.HasFile)
            {
                String fileExtension = System.IO.Path.GetExtension(GameImage.FileName).ToLower();
                String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                    }
                }
            }

            if (fileOK)
            {
                try
                {
                    // Save to Images folder.
                    GameImage.PostedFile.SaveAs(path + GameImage.FileName);
                    // Save to Images/Thumbs folder.
                    GameImage.PostedFile.SaveAs(path + "Thumbs/" + GameImage.FileName);
                }
                catch (Exception ex)
                {
                    LabelAddStatus.Text = ex.Message;
                }

                // Add product data to DB.
                AddGames games = new AddGames();
                bool addSuccess = games.GameAddToList(AddGameName.Text, AddGameDescription.Text,
                    AddGamePrice.Text, DropDownAddConsoles.SelectedValue, GameImage.FileName);
                if (addSuccess)
                {
                    // Reload the page.
                    string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                    Response.Redirect(pageUrl + "?ProductAction=add");
                }
                else
                {
                    LabelAddStatus.Text = "Unable to add new product to database.";
                }
            }
            else
            {
                LabelAddStatus.Text = "Unable to accept file type.";
            }
        }

        public IQueryable GetConsoles()
        {
            var db = new Infanos.Models.Context();
            IQueryable query = db.Consoles;
            return query;
        }

        public IQueryable GetGames()
        {
            var db = new Infanos.Models.Context();
            IQueryable query = db.Games;
            return query;
        }

        protected void RemoveProductButton_Click(object sender, EventArgs e)
        {
            using (var db = new Infanos.Models.Context())
            {
                int gameId = Convert.ToInt16(DropDownRemoveGame.SelectedValue);
                var myItem = (from c in db.Games where c.GameID == gameId select c).FirstOrDefault();
                if (myItem != null)
                {
                    db.Games.Remove(myItem);
                    db.SaveChanges();

                    // Reload the page.
                    string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                    Response.Redirect(pageUrl + "?ProductAction=remove");
                }
                else
                {
                    LabelRemoveStatus.Text = "Unable to locate product.";
                }
            }
        }
    }
}