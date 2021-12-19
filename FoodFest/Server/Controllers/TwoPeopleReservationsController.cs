using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodFest.Server.Data;
using FoodFest.Shared.Domain;
using FoodFest.Server.IRepository;

namespace Foodfest.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwoPeopleReservationsController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public MakesController(ApplicationDbContext context)
        public TwoPeopleReservationsController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Makes
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Make>>> GetMakes()
        public async Task<IActionResult> GetTwoPeopleReservations()
        {
            //return await _context.Makes.ToListAsync();
            var TwoPeopleReservations = await _unitOfWork.TwoPeopleReservations.GetAll();
            return Ok(TwoPeopleReservations);
        }

        // GET: api/Makes/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Make>> GetMake(int id)
        public async Task<IActionResult> GetTwoPeopleReservations(int id)
        {
            //var make = await _context.Makes.FindAsync(id);
            var TwoPeopleReservation = await _unitOfWork.TwoPeopleReservations.Get(q => q.ID == id);

            if (TwoPeopleReservation == null)
            {
                return NotFound();
            }

            return Ok(TwoPeopleReservation);
        }

        // PUT: api/Makes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTwoPeopleReservation(int id, TwoPeopleReservation TwoPeopleReservation)
        {
            if (id != TwoPeopleReservation.ID)
            {
                return BadRequest();
            }

            //_context.Entry(make).State = EntityState.Modified;
            _unitOfWork.TwoPeopleReservations.Update(TwoPeopleReservation);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!MakeExists(id))
                if (!await TwoPeopleReservationExists(id))
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

        // POST: api/Makes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TwoPeopleReservation>> PostTwoPeopleReservation(TwoPeopleReservation TwoPeopleReservation)
        {
            //_context.Makes.Add(make);
            //await _context.SaveChangesAsync();
            await _unitOfWork.TwoPeopleReservations.Insert(TwoPeopleReservation);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetTwoPeopleReservation", new { id = TwoPeopleReservation.ID }, TwoPeopleReservation);
        }

        // DELETE: api/Makes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTwoPeopleReservation(int id)
        {
            //var make = await _context.Makes.FindAsync(id);
            var TwoPeopleReservation = await _unitOfWork.TwoPeopleReservations.Get(q => q.ID == id);
            if (TwoPeopleReservation == null)
            {
                return NotFound();
            }

            //_context.Makes.Remove(make);
            //await _context.SaveChangesAsync();
            await _unitOfWork.TwoPeopleReservations.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool MakeExists(int id)
        private async Task<bool> TwoPeopleReservationExists(int id)
        {
            //return _context.Makes.Any(e => e.Id == id);
            var TwoPeopleReservation = await _unitOfWork.TwoPeopleReservations.Get(q => q.ID == id);
            return TwoPeopleReservation != null;
        }
    }
}