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
    public class AspNetUsersController : ControllerBase
    {
        private readonly dbRevLogContext _context;

        public AspNetUsersController(dbRevLogContext context)
        {
            _context = context;

            //AspNetUsers aspnetuser = new AspNetUsers { UserName = "username1", Email = "testEmail1@gmail.com", PasswordHash = "testpass" };
            //Customer customer = new Customer { RevLogUser = aspnetuser, CustomerSince = DateTime.Now.Date };
            //_context.Customer.Add(customer);
            //_context.SaveChanges();
        }

        // GET: api/AspNetUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AspNetUsers>>> GetAspNetUsers()
        {
            ActionResult <IEnumerable <AspNetUsers>> resultSet = await _context.AspNetUsers.ToListAsync();
            return resultSet;
            
            //return await _context.AspNetUsers.ToListAsync();
        }

        // GET: api/AspNetUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AspNetUsers>> GetAspNetUsers(int id)
        {
            var aspNetUsers = await _context.AspNetUsers.FindAsync(id);

            if (aspNetUsers == null)
            {
                return NotFound();
            }

            return aspNetUsers;
        }

        // PUT: api/AspNetUsers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAspNetUsers(int id, AspNetUsers aspNetUsers)
        {
            if (id != aspNetUsers.Id)
            {
                return BadRequest();
            }

            _context.Entry(aspNetUsers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AspNetUsersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AspNetUsers
        [HttpPost]
        public async Task<ActionResult<AspNetUsers>> PostAspNetUsers(AspNetUsers aspNetUsers)
        {
            _context.AspNetUsers.Add(aspNetUsers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAspNetUsers", new { id = aspNetUsers.Id }, aspNetUsers);
        }

        // DELETE: api/AspNetUsers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AspNetUsers>> DeleteAspNetUsers(int id)
        {
            var aspNetUsers = await _context.AspNetUsers.FindAsync(id);
            if (aspNetUsers == null)
            {
                return NotFound();
            }

            _context.AspNetUsers.Remove(aspNetUsers);
            await _context.SaveChangesAsync();

            return aspNetUsers;
        }

        private bool AspNetUsersExists(int id)
        {
            return _context.AspNetUsers.Any(e => e.Id == id);
        }
    }
}
