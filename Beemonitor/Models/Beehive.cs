using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Beemonitor.Models
{
    public class Beehive
    {
        public int BeehiveId { get; set; }
        [Required]
        [StringLength(255)]
        public string BeehiveName { get; set; }
        public int ApiaryId { get; set; }

        public ICollection<BeehiveSensor> BeehiveSensors { get; set; }
        public Apiary Apiary { get; set; }
    }
}