using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Beemonitor.Models;

namespace Beemonitor.ViewModels
{
    public class BeehiveFormViewModel
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Beehive" : "New Beehive";
            }
        }
        public BeehiveFormViewModel()
        {
            Id = 0;
        }

        public BeehiveFormViewModel(Beehive beehive)
        {
            Id = beehive.Id;
            Name = beehive.Name;
        }
    }
}