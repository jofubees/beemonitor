using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Beemonitor.Models
{
    public class SensorType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SensorTypeId { get; set; }

        public string TypeDescription { get; set; }

        public ICollection<Sensor> Sensors { get; set; }
    }
}