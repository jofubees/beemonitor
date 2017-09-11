using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Beemonitor.Models;

namespace Beemonitor.Dtos
{
    public class ObservationDto
    {
        public int Id { get; set; }
        public string BeehiveId { get; set; }
        public string ObsType { get; set; }
        public float ObsValue { get; set; }
        public DateTime ObsDateTime { get; set; }

    }
}