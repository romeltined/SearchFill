using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SearchFill.Data;
using SearchFill.Models;

namespace SearchFill.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportItems1Controller : ControllerBase
    {
        private readonly SearchFillContext _context;

        public SportItems1Controller(SearchFillContext context)
        {
            _context = context;
        }

        // GET: api/SportItems1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SportItems>>> GetSportItems()
        {
            return await _context.SportItems.ToListAsync();
        }

        // GET: api/SportItems1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SportItems>> GetSportItems(int id)
        {
            var sportItems = await _context.SportItems.Include(s => s.Items).Where(s => s.Id == id).SingleOrDefaultAsync(); //.FindAsync(id);

            if (sportItems == null)
            {
                return NotFound();
            }

            return sportItems;
        }

        // PUT: api/SportItems1/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSportItems(int id, SportItems sportItems)
        {
            if (id != sportItems.Id)
            {
                return BadRequest();
            }

            var existingParent = await _context.SportItems
                                        .Where(p => p.Id == id)
                                        .Include(p => p.Items)
                                        .SingleOrDefaultAsync();

            if (existingParent != null)
            {
                // Update parent
                _context.Entry(existingParent).CurrentValues.SetValues(sportItems);

                // Delete children
                foreach (var existingChild in existingParent.Items.ToList())
                {
                    if (!sportItems.Items.Any(c => c.Id == existingChild.Id))
                        existingParent.Items.Remove(existingChild);
                }

                // Update and Insert children
                foreach (var childModel in sportItems.Items)
                {
                    var existingChild = existingParent.Items
                        .Where(c => c.Id == childModel.Id)
                        .SingleOrDefault();

                    if (existingChild != null)
                        // Update child
                        _context.Entry(existingChild).CurrentValues.SetValues(childModel);
                    else
                    {
                        // Insert child
                        var newChild = new Item
                        {
                            ItemName = childModel.ItemName,
                            //...
                        };
                        existingParent.Items.Add(newChild);
                        await _context.SaveChangesAsync();
                    }
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SportItemsExists(id))
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

        //public async Task<IActionResult> PutSportItems(int id, SportItems sportItems)
        //{
        //    if (id != sportItems.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(sportItems).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!SportItemsExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/SportItems1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SportItems>> PostSportItems(SportItems sportItems)
        {
            _context.SportItems.Add(sportItems);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSportItems", new { id = sportItems.Id }, sportItems);
        }

        // DELETE: api/SportItems1/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SportItems>> DeleteSportItems(int id)
        {
            var sportItems = await _context.SportItems.FindAsync(id);
            if (sportItems == null)
            {
                return NotFound();
            }

            _context.SportItems.Remove(sportItems);
            await _context.SaveChangesAsync();

            return sportItems;
        }

        private bool SportItemsExists(int id)
        {
            return _context.SportItems.Any(e => e.Id == id);
        }
    }
}
