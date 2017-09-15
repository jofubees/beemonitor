using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Beemonitor.Models;

namespace Beemonitor.Dtos
{
    public class ApiaryBeehivesDto
    {
        public IEnumerable<Apiary> Apiaries { get; set; }
        public IEnumerable<Beehive> Beehives { get; set; }
    }
}