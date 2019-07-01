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
    public class ConsigneesController : ControllerBase
    {
        private readonly dbRevLogContext _context;

        public ConsigneesController(dbRevLogContext context)
        {
            _context = context;
        }

        // GET: api/Consignees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Consignee>>> GetConsignee()
        {
            //return await _context.Consignee.ToListAsync();
            return await _context.Consignee
            .Include(e => e.RevLogUser)
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

        // GET: api/Consignees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Consignee>> GetConsignee(int id)
        {
            Consignee @consignee = await _context.Consignee.Include(u => u.RevLogUser).SingleOrDefaultAsync(u => u.ConsigneeId == id) as Consignee;
            //var @consignee = await _context.Consignee.FindAsync(id);

            if (@consignee == null)
            {
                return NotFound();
            }

            return @consignee;
        }

        // PUT: api/Consignees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsignee(int id, Consignee @consignee)
        {
            //Consignee @consignee = await _context.Consignee.Include(u => u.RevLogUser).SingleOrDefaultAsync(u => u.ConsigneeId == id) as Consignee;
            if (id != @consignee.ConsigneeId)
            {
                return BadRequest();
            }

            _context.Entry(@consignee).State = EntityState.Modified;

            try
            {
                using (var _context = new dbRevLogContext())
                {
                    var existingConsignee = _context.Consignee.Where(s => s.ConsigneeId == @consignee.ConsigneeId)
                                                            .FirstOrDefault<Consignee>();

                    if (existingConsignee != null)
                    {
                        existingConsignee.RevLogUser = @consignee.RevLogUser;
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
                if (!ConsigneeExists(id))
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

        // POST: api/Consignees
        [HttpPost]
        public async Task<ActionResult<Consignee>> PostConsignee(Consignee @consignee)
        {
            try
            {
                _context.Consignee.Add(@consignee);
                await _context.SaveChangesAsync();
                return @consignee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //return CreatedAtAction("Details", new { id = @consignee.ConsigneeId }, @consignee);
        }

        // DELETE: api/Consignees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Consignee>> DeleteConsignee(int id)
        {
            Consignee @consignee = await _context.Consignee.Include(u => u.RevLogUser).SingleOrDefaultAsync(u => u.ConsigneeId == id) as Consignee;
            //var @consignee = await _context.Consignee.FindAsync(id);
            if (@consignee == null)
            {
                return NotFound();
            }

            _context.RevLogUser.Remove(@consignee.RevLogUser);
            _context.Consignee.Remove(@consignee);
            await _context.SaveChangesAsync();

            return @consignee;
        }

        private bool ConsigneeExists(int id)
        {
            return _context.Consignee.Any(e => e.ConsigneeId == id);
        }
    }
}
