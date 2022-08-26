using MyProject.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Core.Repository
{
    public class GenericRepository<T>:IGenericRepositoy<T> where T : class
    {
    }
}
