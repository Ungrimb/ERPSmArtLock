using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ERPSmArtLock.Data;
using ERPSmArtLock.Models;

namespace ERPSmArtLock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingListsController : ControllerBase
    {
        private readonly ERPContext _context;

        public BuildingListsController(ERPContext context)
        {
            _context = context;
        }

        // GET: api/BuildingLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuildingList>>> GetBuildingList()
        {
            return await _context.BuildingList.ToListAsync();
        }

        // GET: api/BuildingLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BuildingList>> GetBuildingList(int id)
        {
            var buildingList = await _context.BuildingList.FindAsync(id);

            if (buildingList == null)
            {
                return NotFound();
            }

            return buildingList;
        }

        // PUT: api/BuildingLists/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuildingList(int id, BuildingList buildingList)
        {
            if (id != buildingList.Id)
            {
                return BadRequest();
            }

            _context.Entry(buildingList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuildingListExists(id))
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

        // POST: api/BuildingLists
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BuildingList>> PostBuildingList(BuildingList buildingList)
        {
            _context.BuildingList.Add(buildingList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBuildingList", new { id = buildingList.Id }, buildingList);
        }

        // DELETE: api/BuildingLists/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BuildingList>> DeleteBuildingList(int id)
        {
            var buildingList = await _context.BuildingList.FindAsync(id);
            if (buildingList == null)
            {
                return NotFound();
            }

            _context.BuildingList.Remove(buildingList);
            await _context.SaveChangesAsync();

            return buildingList;
        }

        private bool BuildingListExists(int id)
        {
            return _context.BuildingList.Any(e => e.Id == id);
        }
    }
}
