using MyProject.Core.Models.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Core.Models
{
    public class PagesResult
    {
        public int TotalCount { get; set; }
        public string RangeIndex { get; set; }
        public int RecordNumber { get; set; }
        public List<GeneralList> Items { get; set; }
        
    }
}
