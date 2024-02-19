using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using superheroAPI.Data;

namespace superheroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly DataContext _context;

        //controller
        public SuperHeroController(DataContext context)
        {
            _context = context;
        }

        // get-Method
        [HttpGet]
        public async Task<ActionResult <List<SuperHero>>> GetSuperHeroes()
        {
            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> CreateSuperHero(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateSuperHero(SuperHero hero)
        {
            var dbHero = await _context.SuperHeroes.FindAsync(hero.Id);
            Console.Write(dbHero);
            // if Hero not found than bad request
            if (dbHero == null)
                return BadRequest("Hero not found.");

            // if Hero available, overwright DB record (dbHero) with object (SuperHero hero)
            dbHero.Name = hero.Name;
            dbHero.AlterEgo = hero.AlterEgo;
            dbHero.Publisher = hero.Publisher;
            dbHero.FirstAppearence = hero.FirstAppearence;
            dbHero.PublishingYear = hero.PublishingYear;
            dbHero.CreatedBy = hero.CreatedBy;

            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteSuperHero(int id) 
        {
            // check if Hero is in DB by id.
            var dbHero = await _context.SuperHeroes.FindAsync(id);
            // if Hero not found than bad request
            if (dbHero == null)
            {
                return BadRequest("Hero not found.");
            }
            // if Hero available than delete/remove record from DB
            _context.SuperHeroes.Remove(dbHero);

            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }
    }
}
