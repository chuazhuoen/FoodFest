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
        public async Task<IActionResult> GetFivePeopleTables()
        {
            //return await _context.Makes.ToListAsync();
            var fivePeopleTables = await _unitOfWork.FivePeopleTables.GetAll();
            return Ok(fivePeopleTables);
        }

        // GET: api/Makes/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Make>> GetMake(int id)
        public async Task<IActionResult> GetFivePeopleTables(int id)
        {
            //var make = await _context.Makes.FindAsync(id);
            var fivePeopleTable = await _unitOfWork.FivePeopleTables.Get(q => q.ID == id);

            if (fivePeopleTable == null)
            {
                return NotFound();
            }

            return Ok(fivePeopleTable);
        }

        // PUT: api/Makes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFivePeopleTable(int id, FivePeopleTable fivePeopleTable)
        {
            if (id != fivePeopleTable.ID)
            {
                return BadRequest();
            }

            //_context.Entry(make).State = EntityState.Modified;
            _unitOfWork.FivePeopleTables.Update(fivePeopleTable);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!MakeExists(id))
                if (!await FivePeopleTableExists(id))
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
        public async Task<ActionResult<FivePeopleTable>> PostFivePeopleTable(FivePeopleTable fivePeopleTable)
        {
            //_context.Makes.Add(make);
            //await _context.SaveChangesAsync();
            await _unitOfWork.FivePeopleTables.Insert(fivePeopleTable);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetFivePeopleTable", new { id = fivePeopleTable.ID }, fivePeopleTable);
        }

        // DELETE: api/Makes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFivePeopleTable(int id)
        {
            //var make = await _context.Makes.FindAsync(id);
            var fivePeopleTable = await _unitOfWork.FivePeopleTables.Get(q => q.ID == id);
            if (fivePeopleTable == null)
            {
                return NotFound();
            }

            //_context.Makes.Remove(make);
            //await _context.SaveChangesAsync();
            await _unitOfWork.FivePeopleTables.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool MakeExists(int id)
        private async Task<bool> FivePeopleTableExists(int id)
        {
            //return _context.Makes.Any(e => e.Id == id);
            var fivePeopleTable = await _unitOfWork.FivePeopleTables.Get(q => q.ID == id);
            return fivePeopleTable != null;
        }
    }
}