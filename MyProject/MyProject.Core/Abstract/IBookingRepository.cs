using MyProject.Core.Models;
using MyProject.Core.Models.Booking;
using MyProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Core.Abstract
{
    public interface IBookingRepository:IGenericRepositoy<Booking>
    {
         Task DeleteAsyncByConfirmed(int id);
        Task<PagesResult> GetAllAsyncWithOtherInfomation(QueryParameters queryParameters);
    }
}
