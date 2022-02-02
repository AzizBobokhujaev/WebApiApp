using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAppp.Models;
using AppContext = WebApiAppp.Context.AppContext;

namespace WebApiAppp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        AppContext Context { get; set; }

        public UserController(AppContext context)
        {
            Context = context;
            
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await Context.Users.ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var user = await Context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return new ObjectResult(user);
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<User>> Post(User model)
        {
            Context.Users.Add(model);
            await Context.SaveChangesAsync();
            return Ok(model);
        }

        
        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Put(int id,User model)
        {
            var user = await Context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user==null)
            {
                return BadRequest();
            }

            user.Name = model.Name;
            user.Age = model.Age;

            Context.Update(user);
            await Context.SaveChangesAsync();
            return Ok("Updated");
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            var user = await Context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            Context.Users.Remove(user);
            await Context.SaveChangesAsync();
            return Ok("Deleted");
        }
    }
}
