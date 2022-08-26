using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Core.Abstract;
using MyProject.Entity;

namespace MyProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepo;

        public BookingController(IBookingRepository bookingRepo)
        {
            this._bookingRepo = bookingRepo;
        }
        [HttpGet]
        public async Task<List<Booking>> GetAllBookings()
        {
            return await _bookingRepo.GetAllBookingAsync();
        }
    }
}
