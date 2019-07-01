using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DL.Models;

namespace DL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly dbRevLogContext _context;

        public BookingsController(dbRevLogContext context)
        {
            _context = context;
        }

        // GET: api/Bookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBooking()
        {
            //return await _context.Booking.ToListAsync();
            return await _context.Booking
            .Include(e => e.BookingDetail)
            .Include(e => e.Quotation)
            .ToListAsync();

        }

        // GET: api/Bookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetBooking(int id)
        {
            Booking @booking = await _context.Booking.Include(u => u.BookingDetail).SingleOrDefaultAsync(u => u.BookingId == id) as Booking;
            //var @booking = await _context.Booking.FindAsync(id);

            if (@booking == null)
            {
                return NotFound();
            }

            return @booking;
        }

        // PUT: api/Bookings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooking(int id, Booking @booking)
        {
            //Booking @booking = await _context.Booking.Include(u => u.RevLogUser).SingleOrDefaultAsync(u => u.BookingId == id) as Booking;
            if (id != @booking.BookingId)
            {
                return BadRequest();
            }

            _context.Entry(@booking).State = EntityState.Modified;

            try
            {
                using (var _context = new dbRevLogContext())
                {
                    var existingBooking = _context.Booking.Where(s => s.BookingId == @booking.BookingId)
                                                            .FirstOrDefault<Booking>();

                    if (existingBooking != null)
                    {
                        existingBooking.Quotation.Customer = @booking.Quotation.Customer;
                        existingBooking.Quotation.Operator.CompanyName = @booking.Quotation.Operator.CompanyName;
                        existingBooking.Quotation.Operator.Ntn = @booking.Quotation.Operator.Ntn;
                        _context.SaveChanges();
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            catch (Exception ex)
            {
                if (!BookingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw ex;
                }
            }

            return Ok();
        }

        // POST: api/Bookings
        [HttpPost]
        public async Task<ActionResult<Booking>> PostBooking(Booking @booking)
        {
            try
            {
                _context.Booking.Add(@booking);
                await _context.SaveChangesAsync();
                return @booking;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //return CreatedAtAction("Details", new { id = @booking.BookingId }, @booking);
        }

        // DELETE: api/Bookings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Booking>> DeleteBooking(int id)
        {
            Booking @booking = await _context.Booking.Include(u => u.Quotation).SingleOrDefaultAsync(u => u.BookingId == id) as Booking;
            //var @booking = await _context.Booking.FindAsync(id);
            if (@booking == null)
            {
                return NotFound();
            }

            //Modify db to convert Quotation Status to "Delete+Archive) rather than complete deletion of a quotation without any traces.
            //_context.Quotation.Remove(@booking.Quotation);
            //_context.Booking.Remove(@booking.BookingDetail); //check the right parameter to remove BookingDetail entry
            _context.Booking.Remove(@booking);
            await _context.SaveChangesAsync();

            return @booking;
        }

        private bool BookingExists(int id)
        {
            return _context.Booking.Any(e => e.BookingId == id);
        }
    }
}
