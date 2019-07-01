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
    public class OperatorsController : ControllerBase
    {
        private readonly dbRevLogContext _context;

        public OperatorsController(dbRevLogContext context)
        {
            _context = context;
        }

        // GET: api/Operators
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Operator>>> GetOperator()
        {
            //return await _context.Operator.ToListAsync();
            return await _context.Operator
            .Include(e => e.RevLogUser)
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

        // GET: api/Operators/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Operator>> GetOperator(int id)
        {
            Operator @operator = await _context.Operator.Include(u => u.RevLogUser).SingleOrDefaultAsync(u => u.OperatorId == id) as Operator;
            //var @operator = await _context.Operator.FindAsync(id);

            if (@operator == null)
            {
                return NotFound();
            }

            return @operator;
        }

        // PUT: api/Operators/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOperator(int id, Operator @operator)
        {
            //Operator @operator = await _context.Operator.Include(u => u.RevLogUser).SingleOrDefaultAsync(u => u.OperatorId == id) as Operator;
            if (id != @operator.OperatorId)
            {
                return BadRequest();
            }

            _context.Entry(@operator).State = EntityState.Modified;

            try
            {
                using (var _context = new dbRevLogContext())
                {
                    var existingOperator = _context.Operator.Where(s => s.OperatorId == @operator.OperatorId)
                                                            .FirstOrDefault<Operator>();

                    if (existingOperator != null)
                    {
                        existingOperator.RevLogUser = @operator.RevLogUser;
                        existingOperator.CompanyName = @operator.CompanyName;
                        existingOperator.Ntn = @operator.Ntn;
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
                if (!OperatorExists(id))
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

        // POST: api/Operators
        [HttpPost]
        public async Task<ActionResult<Operator>> PostOperator(Operator @operator)
        {
            try
            {
                _context.Operator.Add(@operator);
                await _context.SaveChangesAsync();
                return @operator;
            }
            catch (Exception ex)
            {
                throw ex;
            }



            //return CreatedAtAction("Details", new { id = @operator.OperatorId }, @operator);
        }

        // DELETE: api/Operators/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Operator>> DeleteOperator(int id)
        {
            Operator @operator = await _context.Operator.Include(u => u.RevLogUser).SingleOrDefaultAsync(u => u.OperatorId == id) as Operator;
            //var @operator = await _context.Operator.FindAsync(id);
            if (@operator == null)
            {
                return NotFound();
            }

            _context.RevLogUser.Remove(@operator.RevLogUser);
            _context.Operator.Remove(@operator);
            await _context.SaveChangesAsync();

            return @operator;
        }

        private bool OperatorExists(int id)
        {
            return _context.Operator.Any(e => e.OperatorId == id);
        }
    }
}
