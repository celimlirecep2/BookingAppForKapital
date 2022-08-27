using AutoMapper;
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
        private readonly IMapper _mapper;

        public BookingRepository(MyProjectDbContext context,IMapper mapper):base(context,mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        
    }
}
