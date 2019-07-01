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
    public class DestinationChargesController : ControllerBase
    {
        private readonly dbRevLogContext _context;

        public DestinationChargesController(dbRevLogContext context)
        {
            _context = context;
        }

        // GET: api/DestinationCharges
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DestinationCharges>>> GetDestinationCharge()
        {
            //return await _context.DestinationCharges.ToListAsync();
            return await _context.DestinationCharges
            .Include(e => e.Quotation)
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

        // GET: api/DestinationCharges/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DestinationCharges>> GetDestinationCharge(int id)
        {
            DestinationCharges @destinationCharges = await _context.DestinationCharges.SingleOrDefaultAsync(u => u.Id == id) as DestinationCharges;
            //var @destinationCharges = await _context.DestinationCharges.FindAsync(id);

            if (@destinationCharges == null)
            {
                return NotFound();
            }

            return @destinationCharges;
        }

        // PUT: api/DestinationCharges/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDestinationCharge(int id, DestinationCharges @destinationCharges)
        {
            //DestinationCharges @destinationCharges = await _context.DestinationCharges.Include(u => u.RevLogUser).SingleOrDefaultAsync(u => u.DestinationChargeId == id) as DestinationCharges;
            if (id != @destinationCharges.Id)
            {
                return BadRequest();
            }

            _context.Entry(@destinationCharges).State = EntityState.Modified;

            try
            {
                using (var _context = new dbRevLogContext())
                {
                    var existingDestinationCharge = _context.DestinationCharges.Where(s => s.Id == @destinationCharges.Id)
                                                            .FirstOrDefault<DestinationCharges>();

                    if (existingDestinationCharge != null)
                    {
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
                if (!DestinationChargeExists(id))
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

        // POST: api/DestinationCharges
        [HttpPost]
        public async Task<ActionResult<DestinationCharges>> PostDestinationCharge(DestinationCharges @destinationCharges)
        {
            try
            {
                _context.DestinationCharges.Add(@destinationCharges);
                await _context.SaveChangesAsync();
                return @destinationCharges;
            }
            catch (Exception ex)
            {
                throw ex;
            }



            //return CreatedAtAction("Details", new { id = @destinationCharges.DestinationChargeId }, @destinationCharges);
        }

        // DELETE: api/DestinationCharges/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DestinationCharges>> DeleteDestinationCharge(int id)
        {
            DestinationCharges @destinationCharges = await _context.DestinationCharges.SingleOrDefaultAsync(u => u.Id == id) as DestinationCharges;
            //var @destinationCharges = await _context.DestinationCharges.FindAsync(id);
            if (@destinationCharges == null)
            {
                return NotFound();
            }

            _context.DestinationCharges.Remove(@destinationCharges);
            await _context.SaveChangesAsync();

            return @destinationCharges;
        }

        private bool DestinationChargeExists(int id)
        {
            return _context.DestinationCharges.Any(e => e.Id == id);
        }
    }
}
