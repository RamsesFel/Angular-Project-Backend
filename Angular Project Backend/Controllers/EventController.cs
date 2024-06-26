﻿using Angular_Project_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Angular_Project_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        EventDbContext dbContext = new EventDbContext();

        [HttpGet()]
        public IActionResult GetAll()
        {
            List<Event> result = dbContext.Events.ToList();
            return Ok(result);
        }

        [HttpPost()]
        public IActionResult AddEvent([FromBody] Event newEvent)
        {
            newEvent.Id = 0;
            dbContext.Events.Add(newEvent);
            dbContext.SaveChanges();
            return Created($"/api/Event/{newEvent.Id}", newEvent);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEvent(int id)
        {
            Event result = dbContext.Events.Find(id);
            if(result == null)
            {
                return NotFound();
            }
            dbContext.Events.Remove(result);
            dbContext.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEvent([FromBody] Event targetEvent, int id)
        {
            if(targetEvent.Id != id)
            {
                return BadRequest();
            }
            if(!dbContext.Events.Any(e=> e.Id == id))
            {
                return NotFound();
            }
            dbContext.Events.Update(targetEvent);
            dbContext.SaveChanges();
            return NoContent();
        }
    }
}
