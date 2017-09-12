using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Beemonitor.Models;

namespace Beemonitor.Dtos
{
    public class NewApiaryBeehiveDto
    {
        public int ApiaryId { get; set; }
        public string ApiaryName { get; set; }
        public Beehive Beehive { get; set; }
    }
}