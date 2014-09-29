using System.ComponentModel.DataAnnotations;

namespace Infanos.Models
{
    public class CartItem
    {
        [Key]
        public string ItemId { get; set; }

        public string CartId { get; set; }

        public int Quantity { get; set; }

        public System.DateTime DateCreated { get; set; }

        public int GameId { get; set; }

        public virtual Games Game { get; set; }

    }
}