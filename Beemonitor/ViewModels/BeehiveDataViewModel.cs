using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Beemonitor.Models;

namespace Beemonitor.ViewModels
{
    public class BeehiveDataViewModel
    {
        public Beehive Beehive { get; set; }
        public ICollection<Sensor> Sensors { get; set;}
        public ICollection<Observation> Observations { get; set; }

        public BeehiveDataViewModel(Beehive beehive)
        {
            Beehive = beehive;

        }

    }
}