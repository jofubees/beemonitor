using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Beemonitor.Migrations;
using Beemonitor.Models;

namespace Beemonitor.ViewModels
{
    public class ApiaryFormViewModel
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string Postcode { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Apiary" : "New Apiary";
            }
        }
        public ApiaryFormViewModel()
        {
            Id = 0;
        }

        public ApiaryFormViewModel(Apiary apiary)
        {
            Id = apiary.ApiaryId;
            Name = apiary.ApiaryName;
            Postcode = apiary.Postcode;
        }
    }
}