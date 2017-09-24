using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Beemonitor.Models;

namespace Beemonitor.ViewModels
{
    public class SensorIndexViewModel
    {
        public Sensor Sensor { get; set; }
        public ICollection<BeehiveSensor> BeehiveSensors { get; set; }
        public SensorType SensorType { get; set; }

        public SensorIndexViewModel(Sensor sensor)
        {
            Sensor = sensor;
            BeehiveSensors = sensor.BeehiveSensors;
            SensorType= sensor.SensorType;
        }

    }
}