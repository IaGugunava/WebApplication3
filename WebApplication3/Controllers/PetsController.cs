using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly PetStoreContext _context;

        public PetsController(PetStoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pets>>> GetPets()
        {
            return await _context.Pets.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pets>> GetPet(int id)
        {
            var pet = await _context.Pets.FindAsync(id);

            if(pet == null)
            {
                return NotFound();
            }

            return pet;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePet(Pets pet)
        {
            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPets", new {id = pet.PetId}, pet);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePet(int id, Pets pet)
        {
            if (id != pet.PetId)
            {
                return BadRequest();
            }

            _context.Entry(pet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePet(int id)
        {
            var pet = await _context.Pets.FindAsync(id);
            if (pet == null)
            {
                return NotFound();
            }

            _context.Pets.Remove(pet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PetExists(int id)
        {
            return _context.Pets.Any(e => e.PetId == id);
        }

    }
}
