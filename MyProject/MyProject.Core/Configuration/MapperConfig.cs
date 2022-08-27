using AutoMapper;
using MyProject.Core.Models.Booking;
using MyProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Core.Configuration
{
    public class MapperConfig:Profile
    {
        public MapperConfig()
        {
            #region Booking
            CreateMap<Booking, BookingDTO>().ReverseMap();
            CreateMap<Booking, UpdateBookingDTO>().ReverseMap();
            CreateMap<Booking, CreateBookingDTO>().ReverseMap();
            CreateMap<Booking, GetBookingDTO>().ReverseMap();

            #endregion

            #region Appartment


            #endregion

            #region Company


            #endregion

            #region User

            #endregion

        }
    }
}
