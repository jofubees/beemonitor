using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Beemonitor.Models;

namespace Beemonitor.ViewModels
{
    public class BeehiveDataViewModel
    {
//        Sites[0].Sensors[0].Observations[0]

            public Beehive Beehive { get; set; }
            public IEnumerable<Sensor> Sensors { get; set;}
            public IEnumerable<Observation> Observations { get; set; }

        //        public BeehiveDataViewModel()
        //      {
        //        
        //  }

        //        public BeehiveDataViewModel(Beehive beehive)
        //      {
        //        Beehive = beehive;
        //  }

    }
}