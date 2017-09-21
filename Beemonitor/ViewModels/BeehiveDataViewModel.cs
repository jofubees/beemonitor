using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Beemonitor.Controllers.Api;
using Beemonitor.Models;

namespace Beemonitor.ViewModels
{
    public class BeehiveDataViewModel
    {
        //       public Beehive[0].Sensor[0].Observation;
        public Beehive Beehive { get; set; }
    }
}

/*        public ICollection<Sensor> Sensors { get; set; }

        public BeehiveDataViewModel()
        {
            Beehive.Id = 0;
        }

        public BeehiveDataViewModel(Beehive beehive)
        {
            Beehive Beehive = beehive;
            ICollection<Sensor> Sensors = beehive.Sensors;
        }
    }
}
*/