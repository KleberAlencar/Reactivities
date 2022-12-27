using System.Diagnostics;
using Persistence;
using Microsoft.AspNetCore.Mvc;
using Activity = Domain.Activity;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        private readonly DataContext _context;

        public ActivitiesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet] //api/activities
        public async Task<ActionResult<List<Activity>>> Search() {
            return await _context.Activities.ToListAsync();
        }

        [HttpGet("{id}")] // api/activities/id
        public async Task<ActionResult<Activity>> Get(Guid id) {
            return await _context.Activities.FindAsync(id);
        }
    }
}