﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Beemonitor.Models;

namespace Beemonitor.ViewModels
{
    public class ApiaryBeehivesViewModel
    {
        public Apiary Apiary { get; set; }
        public List<Beehive> Beehive { get; set; }
    }
}