using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistance;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly DataContext _context;
        public ActivityController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetActivities()
        {
            return Ok(await _context.Activities.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivityById(Guid id)
        {
            return Ok(await _context.Activities.FindAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity(Activity activity)
        {
            _context.Activities.Add(activity);
            return Ok(await _context.SaveChangesAsync());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            var activity = await _context.Activities.FindAsync(id);
            if (activity == null) return BadRequest();
            _context.Activities.Remove(activity);
            return Ok(await _context.SaveChangesAsync());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActivity(Guid id,Activity activity)
        {
            var thisActivity = await _context.Activities.FindAsync(id);
            if (activity == null) return BadRequest();
            thisActivity.Name = activity.Name;
            thisActivity.Description = activity.Description;
            thisActivity.Tags = activity.Tags;
            _context.Activities.Update(activity);
            return Ok(await _context.SaveChangesAsync());
        }
    }
}
