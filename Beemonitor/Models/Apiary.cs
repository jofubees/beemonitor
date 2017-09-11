using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Beemonitor.Models
{
    public class Apiary
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "please enter a name for your apiary")]
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(10)]
        public string Postcode { get; set; }
    }
}