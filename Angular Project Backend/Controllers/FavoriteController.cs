using Angular_Project_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Angular_Project_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        
        EventDbContext dbContext = new EventDbContext();

        [HttpGet()]
        public IActionResult GetAll()
        {
            List<Favorite> result = dbContext.Favorites.ToList();
            return Ok(result);
        }

        [HttpPost()]
        public IActionResult AddFavorite([FromBody] Favorite newFavorite)
        {
            newFavorite.Id = 0;
            dbContext.Favorites.Add(newFavorite);
            dbContext.SaveChanges();
            return Created($"/api/Favorite/{newFavorite.Id}", newFavorite);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFavorite(int id)
        {
            Favorite result = dbContext.Favorites.Find(id);
            if (result == null)
            {
                return NotFound();
            }
            dbContext.Favorites.Remove(result);
            dbContext.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFavorite([FromBody] Favorite targetFavorite, int id)
        {
            if (targetFavorite.Id != id)
            {
                return BadRequest();
            }
            if (!dbContext.Favorites.Any(e => e.Id == id))
            {
                return NotFound();
            }
            dbContext.Favorites.Update(targetFavorite);
            dbContext.SaveChanges();
            return NoContent();
        }
    }
       
}
