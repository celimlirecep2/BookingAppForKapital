using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MyProject.Core.Abstract;
using MyProject.Core.Models;
using MyProject.Core.Models.Booking;
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
        public async Task DeleteAsyncByConfirmed(int id)
        {
            if (id == 0)
                throw new ArgumentNullException(nameof(DeleteAsync));
            var entity= await _context.bookings.FindAsync(id);
            if (entity is null)
                throw new ArgumentNullException(nameof(DeleteAsync));
            if (entity.confirmed == 1)
                throw new ArgumentException($"{id} registered product is approved cannot be deleted");
            _context.bookings.Remove(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<PagesResult> GetAllAsyncWithOtherInfomation(QueryParameters queryParameters)
        {
            //tablolar bibiriyle ilişkilendirilmemiş mecburen tek tek istek atmak zorunda kaldım
            var bookingSıze = await _context.bookings.CountAsync();
            var bookingList = await _context.bookings
                .Skip(queryParameters.StartIndex)
                .Take(queryParameters.PageSize)
                .ToListAsync();

            List<GeneralList> results = new();
            foreach (var item in bookingList)
            {
                GeneralList generalList = new GeneralList();
                generalList.starts_at = Convert.ToDateTime( item.starts_at);
                generalList.booked_at = Convert.ToDateTime( item.booked_at);
                generalList.confirmed = item.confirmed;

                var user = await _context.users.FirstOrDefaultAsync(i => i.id == item.user_id);
                if (user != null)
                {
                    generalList.first_name = user.first_name;
                    generalList.last_name = user.last_name;
                    generalList.email = user.email;
                    generalList.phone = user.phone;
                    generalList.phone = user.phone;
                }

                var appartment = await _context.appartments.FirstOrDefaultAsync(i => i.id == item.apartment_id);
                if (appartment!=null)
                {
                    generalList.address2 = appartment.address2;
                    generalList.adress = appartment.address;
                    generalList.zip_code = appartment.zip_code;
                    generalList.city = appartment.city;
                    generalList.AppartmentName = appartment.name;
                }

                results.Add(generalList);
            }

            return new PagesResult
            {
                RecordNumber = queryParameters.PageSize,
                RangeIndex = $"Data from {queryParameters.StartIndex} to {queryParameters.StartIndex + queryParameters.PageSize}",
                TotalCount = bookingSıze,
                Items = results
            };
        }
    }
}
