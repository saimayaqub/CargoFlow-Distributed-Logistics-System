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
    public class CargoDetailsController : ControllerBase
    {
        private readonly dbRevLogContext _context;

        public CargoDetailsController(dbRevLogContext context)
        {
            _context = context;
        }

        // GET: api/CargoDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CargoDetail>>> GetCargoDetail()
        {
            //return await _context.CargoDetail.ToListAsync();
            return await _context.CargoDetail
            .Include(e => e.CartonSpecs)
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

        // GET: api/CargoDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CargoDetail>> GetCargoDetail(int id)
        {
            CargoDetail @cargoDetail = await _context.CargoDetail.Include(u => u.CartonSpecs).SingleOrDefaultAsync(u => u.CargoDetailId == id) as CargoDetail;

            if (@cargoDetail == null)
            {
                return NotFound();
            }
            return @cargoDetail;
        }

        // PUT: api/CargoDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCargoDetail(int id, CargoDetail @cargoDetail)
        {
            if (id != @cargoDetail.CargoDetailId)
            {
                return BadRequest();
            }

            _context.Entry(@cargoDetail).State = EntityState.Modified;

            try
            {
                using (var _context = new dbRevLogContext())
                {
                    var existingCargoDetail = _context.CargoDetail.Where(s => s.CargoDetailId == @cargoDetail.CargoDetailId)
                                                            .FirstOrDefault<CargoDetail>();

                    if (existingCargoDetail != null)
                    {
                        existingCargoDetail.CartonSpecs = @cargoDetail.CartonSpecs;
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
                if (!CargoDetailExists(id))
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

        // POST: api/CargoDetails
        [HttpPost]
        public async Task<ActionResult<CargoDetail>> PostCargoDetail(CargoDetail @cargoDetail)
        {
            try
            {
                _context.CargoDetail.Add(@cargoDetail);
                await _context.SaveChangesAsync();
                return @cargoDetail;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        // DELETE: api/CargoDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CargoDetail>> DeleteCargoDetail(int id)
        {
            CargoDetail @cargoDetail = await _context.CargoDetail.Include(u => u.CartonSpecs).SingleOrDefaultAsync(u => u.CargoDetailId == id) as CargoDetail;
            if (@cargoDetail == null)
            {
                return NotFound();
            }

            _context.CartonSpecs.RemoveRange(@cargoDetail.CartonSpecs);
            _context.CargoDetail.Remove(@cargoDetail);
            await _context.SaveChangesAsync();
            return @cargoDetail;
        }

        private bool CargoDetailExists(int id)
        {
            return _context.CargoDetail.Any(e => e.CargoDetailId == id);
        }
    }
}
