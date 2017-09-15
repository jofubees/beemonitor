using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Beemonitor.Models;

namespace Beemonitor.ViewModels
{
    public class ApiaryDetailsViewModel
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string Postcode { get; set; }

        public ICollection<Beehive> Beehives { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Apiary" : "New Apiary";
            }
        }
        public ApiaryDetailsViewModel()
        {
            Id = 0;
        }

        public ApiaryDetailsViewModel(Apiary apiary)
        {
            Id = apiary.Id;
            Name = apiary.Name;
            Postcode = apiary.Postcode;
            Beehives = apiary.Beehives;
        }

    }
}