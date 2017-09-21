using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Beemonitor.Models
{
    public class Sensor
    {
        [Key]
        public string SensorName { get; set; }
        public int SensorTypeId { get; set; }
        public int BeehiveId { get; set; }

        public virtual Beehive Beehive { get; set; }
        public virtual SensorType SensorType { get; set; }
        public virtual ICollection<Observation> Observations { get; set; }
    }
}