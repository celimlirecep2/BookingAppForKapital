using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Entity
{
    public class Appartment
    {
        public int id { get; set; }
        public string name { get; set; }
        public string iamage { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string zip_code { get; set; }
        public string adress { get; set; }
        public string address2 { get; set; }
        public int latitude { get; set; }
        public int longitude { get; set; }
        public string direction { get; set; }
        public int booked { get; set; }

    }
}
