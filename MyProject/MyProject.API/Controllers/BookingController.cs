
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.OData.Query;
using MyProject.Core.Abstract;
using MyProject.Core.Models;
using MyProject.Core.Models.Booking;
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

        // api/booking/getallbookings/?startindex=0&pageNumber=1
        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<PagesResult>> GetAllBookings([FromQuery] QueryParameters queryParameters)
        {
            var pagesBookingResult= await _bookingRepo.GetAllAsyncWithOtherInfomation(queryParameters);
            return Ok(pagesBookingResult);
        }

        // PUT: api/booking/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooking(int id, UpdateBookingDTO updateBookingDTO)
        {

            if (id != updateBookingDTO.id)
                    return BadRequest();
            try
            {
                await _bookingRepo.UpdateAsync(id, updateBookingDTO);
              
            }
            catch (Exception)
            {
                throw;
            }
            return NoContent();
        }
        // POST: api/booking
        [HttpPost]
        public async Task<ActionResult<BookingDTO>> PostBooking(CreateBookingDTO bookingDTO)
        {
            var lastValue = await _bookingRepo.GetLastAsync(i=>i.id);
            bookingDTO.id = lastValue.id+1;
            var country = await _bookingRepo.AddAsync<CreateBookingDTO, GetBookingDTO>(bookingDTO);
            return CreatedAtAction("PostBooking", new { id = country.id }, country);
        }

        // DELETE: api/booking/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            await _bookingRepo.DeleteAsyncByConfirmed(id);
            return NoContent();
        }

        // GET: api/booking/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingDTO>> GetBooking(int id)
        {
            var bookingDto = await _bookingRepo.GetAsync<BookingDTO>(id);
            return Ok(bookingDto);
        }

    }

   
}
