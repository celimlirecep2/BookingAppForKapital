using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Core.Models
{
    public class PagesResult<T>
    {
        public int TotalCount { get; set; }
        public int RecordNumber { get; set; }
        public List<T> Items { get; set; }
    }
}
