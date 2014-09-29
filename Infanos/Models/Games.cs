

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Infanos.Models
{
    public class Games
    {
        [Key]
        [ScaffoldColumn(false)]
        public int GameID { get; set; }

        [Required, StringLength(100), Display(Name = "Name")]
        public string GameName { get; set; }

        [Required, StringLength(10000), Display(Name = "Game Description"), DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public string ImagePath { get; set; }

        [Display(Name = "Price")]
        public double? GamePrice { get; set; }

        public int? ConsoleID { get; set; }

        public virtual Consoles Consoles { get; set; }
    }
}