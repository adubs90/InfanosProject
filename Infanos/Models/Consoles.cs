using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Infanos.Models
{
    public class Consoles
    {
        [Key]
        [ScaffoldColumn(false)]
        public int ConsoleID { get; set; }

        [Required, StringLength(100), Display(Name = "Name")]
        public string ConsoleName { get; set; }

        [Display(Name = "Console Description")]
        public string Description { get; set; }

        public virtual ICollection<Games> Games { get; set; }
    }
}