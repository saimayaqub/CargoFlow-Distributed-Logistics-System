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
    public class BookingDetailsController : ControllerBase
    {
        private readonly dbRevLogContext _context;

        public BookingDetailsController(dbRevLogContext context)
        {
            _context = context;
        }

        // GET: api/BookingDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingDetail>>> GetBookingDetail()
        {
            //return await _context.BookingDetail.ToListAsync();
            return await _context.BookingDetail
            .ToListAsync();

            //following code also generates internal objects but for selected columns only, thus more efficient:

            //var query = _dbContext.Users
            //    .Select(user => new User
            //    {
            //        Emails = user.Emails.Select(email => new Email { Address = email.Address }).ToList(),
            //        Phones = user.Phones.Select(phone => new Phone { Number = phone.Number }).ToList()
            //    });

            //var result = await query.ToListAsync();

        }

        // GET: api/BookingDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingDetail>> GetBookingDetail(int id)
        {
            BookingDetail @bookingDetail = await _context.BookingDetail.SingleOrDefaultAsync(u => u.BookingDetailId == id) as BookingDetail;
            
            if (@bookingDetail == null)
            {
                return NotFound();
            }

            return @bookingDetail;
        }

        // PUT: api/BookingDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookingDetail(int id, BookingDetail @bookingDetail)
        {
            //BookingDetail @bookingDetail = await _context.BookingDetail.SingleOrDefaultAsync(u => u.BookingDetailId == id) as BookingDetail;
            if (id != @bookingDetail.BookingDetailId)
            {
                return BadRequest();
            }

            _context.Entry(@bookingDetail).State = EntityState.Modified;

            try
            {
                using (var _context = new dbRevLogContext())
                {
                    var existingBookingDetail = _context.BookingDetail.Where(s => s.BookingDetailId == @bookingDetail.BookingDetailId)
                                                            .FirstOrDefault<BookingDetail>();

                    if (existingBookingDetail != null)
                    {
                        existingBookingDetail.TransShipmentPort1 = @bookingDetail.TransShipmentPort1;
                        existingBookingDetail.TransShipmentPort2 = @bookingDetail.TransShipmentPort2;
                        existingBookingDetail.Eta = @bookingDetail.Eta;
                        existingBookingDetail.Etd = @bookingDetail.Etd;
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
                if (!BookingDetailExists(id))
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

        // POST: api/BookingDetails
        [HttpPost]
        public async Task<ActionResult<BookingDetail>> PostBookingDetail(BookingDetail @bookingDetail)
        {
            try
            {
                _context.BookingDetail.Add(@bookingDetail);
                await _context.SaveChangesAsync();
                return @bookingDetail;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // DELETE: api/BookingDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookingDetail>> DeleteBookingDetail(int id)
        {
            BookingDetail @bookingDetail = await _context.BookingDetail.SingleOrDefaultAsync(u => u.BookingDetailId == id) as BookingDetail;
            if (@bookingDetail == null)
            {
                return NotFound();
            }

            _context.Booking.Remove(@bookingDetail.Booking);
            _context.BookingDetail.Remove(@bookingDetail);
            await _context.SaveChangesAsync();

            return @bookingDetail;
        }

        private bool BookingDetailExists(int id)
        {
            return _context.BookingDetail.Any(e => e.BookingDetailId == id);
        }
    }
}
