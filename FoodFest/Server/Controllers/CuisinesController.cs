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
    public class FivePeopleTablesController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public MakesController(ApplicationDbContext context)
        public FivePeopleTablesController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Makes
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Make>>> GetMakes()
        public async Task<IActionResult> GetCuisines()
        {
            //return await _context.Makes.ToListAsync();
            var cuisines = await _unitOfWork.Cuisines.GetAll();
            return Ok(cuisines);
        }

        // GET: api/Makes/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Make>> GetMake(int id)
        public async Task<IActionResult> GetCuisines(int id)
        {
            //var make = await _context.Makes.FindAsync(id);
            var cuisine = await _unitOfWork.Cuisines.Get(q => q.ID == id);

            if (cuisine == null)
            {
                return NotFound();
            }

            return Ok(cuisine);
        }

        // PUT: api/Makes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCuisine (int id, Cuisine cuisine)
        {
            if (id != cuisine.ID)
            {
                return BadRequest();
            }

            //_context.Entry(make).State = EntityState.Modified;
            _unitOfWork.Cuisines.Update(cuisine);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!MakeExists(id))
                if (!await CuisineExists(id))
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
        public async Task<ActionResult<Cuisine>> PostCuisine(Cuisine cuisine)
        {
            //_context.Makes.Add(make);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Cuisines.Insert(cuisine);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetCuisine", new { id = cuisine.ID }, cuisine);
        }

        // DELETE: api/Makes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCuisine(int id)
        {
            //var make = await _context.Makes.FindAsync(id);
            var cuisine = await _unitOfWork.Cuisines.Get(q => q.ID == id);
            if (cuisine == null)
            {
                return NotFound();
            }

            //_context.Makes.Remove(make);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Cuisines.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool MakeExists(int id)
        private async Task<bool> CuisineExists(int id)
        {
            //return _context.Makes.Any(e => e.Id == id);
            var cuisine = await _unitOfWork.Cuisines.Get(q => q.ID == id);
            return cuisine != null;
        }
    }
}
