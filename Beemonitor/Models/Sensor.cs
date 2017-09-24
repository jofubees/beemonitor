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
        [StringLength(50, MinimumLength = 3)]
        public string SensorName { get; set; }
        public int SensorTypeId { get; set; }

        public ICollection<BeehiveSensor> BeehiveSensors { get; set; }
        public ICollection<Observation> Observations { get; set; }
        public SensorType SensorType { get; set; }
    }
}