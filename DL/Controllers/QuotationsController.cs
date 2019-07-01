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
    public class QuotationsController : ControllerBase
    {
        private readonly dbRevLogContext _context;

        public QuotationsController(dbRevLogContext context)
        {
            _context = context;
        }

        // GET: api/Quotations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quotation>>> GetQuotation()
        {
            //return await _context.Quotation.ToListAsync();
            return await _context.Quotation
            .Include(e => e.Customer)
            .Include(e => e.Operator)
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

        // GET: api/Quotations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Quotation>> GetQuotation(int id)
        {
            Quotation @quotation = await _context.Quotation.Include(u => u.Customer).SingleOrDefaultAsync(u => u.QuotationId == id) as Quotation;
            //var @quotation = await _context.Quotation.FindAsync(id);

            if (@quotation == null)
            {
                return NotFound();
            }

            return @quotation;
        }

        // PUT: api/Quotations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuotation(int id, Quotation @quotation)
        {
            //Quotation @quotation = await _context.Quotation.Include(u => u.RevLogUser).SingleOrDefaultAsync(u => u.QuotationId == id) as Quotation;
            if (id != @quotation.QuotationId)
            {
                return BadRequest();
            }

            _context.Entry(@quotation).State = EntityState.Modified;

            try
            {
                using (var _context = new dbRevLogContext())
                {
                    var existingQuotation = _context.Quotation.Where(s => s.QuotationId == @quotation.QuotationId)
                                                            .FirstOrDefault<Quotation>();

                    if (existingQuotation != null)
                    {
                        existingQuotation.Customer = @quotation.Customer;
                        existingQuotation.Operator.CompanyName = @quotation.Operator.CompanyName;
                        existingQuotation.Operator.Ntn = @quotation.Operator.Ntn;
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
                if (!QuotationExists(id))
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

        // POST: api/Quotations
        [HttpPost]
        public async Task<ActionResult<Quotation>> PostQuotation(Quotation @quotation)
        {
            try
            {
                _context.Quotation.Add(@quotation);
                await _context.SaveChangesAsync();
                return @quotation;
            }
            catch (Exception ex)
            {
                throw ex;
            }



            //return CreatedAtAction("Details", new { id = @quotation.QuotationId }, @quotation);
        }

        // DELETE: api/Quotations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Quotation>> DeleteQuotation(int id)
        {
            Quotation @quotation = await _context.Quotation.Include(u => u.Customer).SingleOrDefaultAsync(u => u.QuotationId == id) as Quotation;
            //var @quotation = await _context.Quotation.FindAsync(id);
            if (@quotation == null)
            {
                return NotFound();
            }

            _context.Customer.Remove(@quotation.Customer);
            _context.Quotation.Remove(@quotation);
            await _context.SaveChangesAsync();

            return @quotation;
        }

        private bool QuotationExists(int id)
        {
            return _context.Quotation.Any(e => e.QuotationId == id);
        }
    }
}
