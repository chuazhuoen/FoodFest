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
    public class TwoPeopleTablesController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public MakesController(ApplicationDbContext context)
        public TwoPeopleTablesController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Makes
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Make>>> GetMakes()
        public async Task<IActionResult> GetTwoPeopleTables()
        {
            //return await _context.Makes.ToListAsync();
            var TwoPeopleTables = await _unitOfWork.TwoPeopleTables.GetAll();
            return Ok(TwoPeopleTables);
        }

        // GET: api/Makes/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Make>> GetMake(int id)
        public async Task<IActionResult> GetTwoPeopleTables(int id)
        {
            //var make = await _context.Makes.FindAsync(id);
            var TwoPeopleTable = await _unitOfWork.TwoPeopleTables.Get(q => q.ID == id);

            if (TwoPeopleTable == null)
            {
                return NotFound();
            }

            return Ok(TwoPeopleTable);
        }

        // PUT: api/Makes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTwoPeopleTable(int id, TwoPeopleTable TwoPeopleTable)
        {
            if (id != TwoPeopleTable.ID)
            {
                return BadRequest();
            }

            //_context.Entry(make).State = EntityState.Modified;
            _unitOfWork.TwoPeopleTables.Update(TwoPeopleTable);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!MakeExists(id))
                if (!await TwoPeopleTableExists(id))
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
        public async Task<ActionResult<TwoPeopleTable>> PostTwoPeopleTable(TwoPeopleTable TwoPeopleTable)
        {
            //_context.Makes.Add(make);
            //await _context.SaveChangesAsync();
            await _unitOfWork.TwoPeopleTables.Insert(TwoPeopleTable);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetTwoPeopleTable", new { id = TwoPeopleTable.ID }, TwoPeopleTable);
        }

        // DELETE: api/Makes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTwoPeopleTable(int id)
        {
            //var make = await _context.Makes.FindAsync(id);
            var TwoPeopleTable = await _unitOfWork.TwoPeopleTables.Get(q => q.ID == id);
            if (TwoPeopleTable == null)
            {
                return NotFound();
            }

            //_context.Makes.Remove(make);
            //await _context.SaveChangesAsync();
            await _unitOfWork.TwoPeopleTables.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool MakeExists(int id)
        private async Task<bool> TwoPeopleTableExists(int id)
        {
            //return _context.Makes.Any(e => e.Id == id);
            var TwoPeopleTable = await _unitOfWork.TwoPeopleTables.Get(q => q.ID == id);
            return TwoPeopleTable != null;
        }
    }
}