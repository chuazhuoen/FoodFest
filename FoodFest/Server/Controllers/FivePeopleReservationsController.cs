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

namespace FoodFest.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FivePeopleReservationsController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public MakesController(ApplicationDbContext context)
        public FivePeopleReservationsController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Makes
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Make>>> GetMakes()
        public async Task<IActionResult> GetFivePeopleReservations()
        {
            //return await _context.Makes.ToListAsync();
            var fivePeopleReservations = await _unitOfWork.FivePeopleReservations.GetAll();
            return Ok(fivePeopleReservations);
        }

        // GET: api/Makes/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Make>> GetMake(int id)
        public async Task<IActionResult> GetFivePeopleReservations(int id)
        {
            //var make = await _context.Makes.FindAsync(id);
            var fivePeopleReservation = await _unitOfWork.FivePeopleReservations.Get(q => q.ID == id);

            if (fivePeopleReservation == null)
            {
                return NotFound();
            }

            return Ok(fivePeopleReservation);
        }

        // PUT: api/Makes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFivePeopleReservation(int id, FivePeopleReservation fivePeopleReservation)
        {
            if (id != fivePeopleReservation.ID)
            {
                return BadRequest();
            }

            //_context.Entry(make).State = EntityState.Modified;
            _unitOfWork.FivePeopleReservations.Update(fivePeopleReservation);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!MakeExists(id))
                if (!await FivePeopleReservationExists(id))
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
        public async Task<ActionResult<FivePeopleReservation>> PostFivePeopleReservation(FivePeopleReservation fivePeopleReservation)
        {
            //_context.Makes.Add(make);
            //await _context.SaveChangesAsync();
            await _unitOfWork.FivePeopleReservations.Insert(fivePeopleReservation);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetFivePeopleReservation", new { id = fivePeopleReservation.ID }, fivePeopleReservation);
        }

        // DELETE: api/Makes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFivePeopleReservation(int id)
        {
            //var make = await _context.Makes.FindAsync(id);
            var fivePeopleReservation = await _unitOfWork.FivePeopleReservations.Get(q => q.ID == id);
            if (fivePeopleReservation == null)
            {
                return NotFound();
            }

            //_context.Makes.Remove(make);
            //await _context.SaveChangesAsync();
            await _unitOfWork.FivePeopleReservations.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool MakeExists(int id)
        private async Task<bool> FivePeopleReservationExists(int id)
        {
            //return _context.Makes.Any(e => e.Id == id);
            var fivePeopleReservation = await _unitOfWork.FivePeopleReservations.Get(q => q.ID == id);
            return fivePeopleReservation != null;
        }
    }
}