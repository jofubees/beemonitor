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
        public int SiteId { get; set; }
        public ICollection<Observation> Observations { get; set; }
    }
}