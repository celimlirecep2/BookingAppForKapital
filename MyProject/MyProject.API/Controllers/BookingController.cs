using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        //api/booking/getallbookings/?startindex=0&pageNumber=1
        [HttpGet]
        public async Task<ActionResult<PagesResult<BookingDTO>>> GetAllBookings([FromQuery] QueryParameters queryParameters)
        {
            var pagesBookingResult= await _bookingRepo.GetAllAsync<BookingDTO>(queryParameters);
            return Ok(pagesBookingResult);
        }


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

        [HttpPost]
        public async Task<ActionResult<BookingDTO>> PostBooking(CreateBookingDTO bookingDTO)
        {

            var country = await _bookingRepo.AddAsync<CreateBookingDTO, GetBookingDTO>(bookingDTO);
            return CreatedAtAction("PostBooking", new { id = country.id }, country);
        }

        // DELETE: api/booking/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            await _bookingRepo.DeleteAsync(id);
            return NoContent();
        }

    }
}
