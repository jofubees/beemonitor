using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beemonitor.Models
{
    public class Observation
    {
        public int Id { get; set; }
        public string SensorName { get; set; }
        public float ObsValue { get; set; }
        public DateTime ObsDateTime { get; set; }
    }
}