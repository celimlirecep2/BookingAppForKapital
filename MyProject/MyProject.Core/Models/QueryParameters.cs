using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Core.Models
{
    public class QueryParameters
    {
        public int StartIndex { get; set; }=0;
        public int PageSize = 10;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? AppartmentName { get; set; }
        public int? Confirmed { get; set; }





    }
}
