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

        public int ApiaryId;

        public string Title
        {
            get
            {
                if (Id == 0 )
                    return "New Beehive";
                else
                    return "Edit Beehive";
            }
        }
        public BeehiveFormViewModel()
        {
            Id = 0;
        }

        public BeehiveFormViewModel(Beehive beehive)
        {
            Id = beehive.BeehiveId;
            Name = beehive.BeehiveName;
            ApiaryId = beehive.ApiaryId;
        }
    }
}