using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonApplicationDll.Entities;

namespace PersonWebApp.Models
{
    public class EditPersonViewModel
    {
        public Person Person { get; set; }
        public List<PersonStatus> Statuses { get; set; }
    }
}