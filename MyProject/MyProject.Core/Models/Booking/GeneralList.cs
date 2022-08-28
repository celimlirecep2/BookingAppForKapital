using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Core.Models.Booking
{
    public class GeneralList
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string AppartmentName { get; set; }
        public string adress { get; set; }
        public string address2 { get; set; }
        public string zip_code { get; set; }
        public string city { get; set; }
        public DateTime starts_at { get; set; }
        public DateTime booked_at { get; set; }
        public int confirmed { get; set; }
    }
}
