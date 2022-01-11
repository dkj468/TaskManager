using Application.Activities;
using Domain;
using MediatR;
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
    public class ActivityController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetActivities()
        {
            return Ok(await Mediator.Send(new ListActivity.Query()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivityById(Guid id)
        {
            return Ok(await Mediator.Send(new ActivityDetail.Query { Id=id}));
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity(Activity activity)
        {
           
            return Ok(await Mediator.Send(new CreateActivity.Command { Activity = activity}));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            
            return Ok(await Mediator.Send(new DeleteActivity.Command { id=id}));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActivity(Guid id,Activity activity)
        {
            activity.Id = id;
            return Ok(await Mediator.Send(new EditActivity.Command
            {
                Activity = activity,
                id = id
            }));
        }
    }
}
