using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Beemonitor.Models
{
    public class Beehive
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public int ApiaryId { get; set; }

        public ICollection<Sensor> Sensors { get; set; }

        //        public virtual Apiary Apiary { get; set; }
    }
}