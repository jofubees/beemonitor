using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Beemonitor.Models
{
    public class BeehiveSensor
    {
        public int BeehiveId { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string SensorName { get; set; }

        public virtual Beehive Beehive { get; set; }
        public virtual Sensor Sensor { get; set; }

    }
}