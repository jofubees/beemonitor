using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Beemonitor.Models
{
    public class Apiary
    {
        public int ApiaryId { get; set; }
        [Required(ErrorMessage = "please enter a name for your apiary")]
        [StringLength(255)]
        public string ApiaryName { get; set; }
        [StringLength(10)]
        public string Postcode { get; set; }

        public virtual ICollection<Beehive> Beehives { get; set; }

    }
}