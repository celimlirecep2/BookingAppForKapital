using Microsoft.EntityFrameworkCore;
using MyProject.Core.Abstract;
using MyProject.Data;
using MyProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Core.Repository
{
    public class BookingRepository:GenericRepository<Booking>,IBookingRepository
    {
        private readonly MyProjectDbContext _context;

        public BookingRepository(MyProjectDbContext context)
        {
            this._context = context;
        }
        public async Task<List<Booking>> GetAllBookingAsync()
        {
            return await _context.bookings.ToListAsync();
        }
    }
}
