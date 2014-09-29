using System.ComponentModel.DataAnnotations;

namespace Infanos.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }

        public int OrderId { get; set; }

        public string Username { get; set; }

        public int GameId { get; set; }

        public int Quantity { get; set; }

        public double? GamePrice { get; set; }

    }
}