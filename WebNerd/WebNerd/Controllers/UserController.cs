using WebNerd.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebNerd.Controllers
{
    [RoutePrefix("api/Users")]
    public class UserController : ApiController
    {
        [Route("GetAll")]
        [HttpGet]
        public IHttpActionResult GetAllUsers() //check
        {
            IEnumerable<User> users;
            using (var context = new EfDbContext())
            {
                users = context.Users.Include(u => u.Games).ToList();
            }
            return Ok(users);
        }
        
        [Route("GetUser/{id:int}")]
        [HttpGet]
        public IHttpActionResult GetUser(int id) //check
        {
            User user;
            using (var context = new EfDbContext())
            {
                user = context.Users.Include(u => u.Games).SingleOrDefault(u => u.Id == id);
            }
            return Ok(user);
        }

        // POST: api/Game 
        [HttpGet]
        public IHttpActionResult PostUser([FromBody]User user) //nawet nie wiem jak sprawdzic :)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (var context = new EfDbContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }

            return CreatedAtRoute("GetStudent", new { id = user.Id }, user);
        }

        // PUT: api/User/5
        [HttpGet]
        public IHttpActionResult PutUser(int id, [FromBody]User user) //tego też nie :)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest();
            }
            using (var context = new EfDbContext()) try
            {
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (user == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("DeleteUser/{id:int}")]
        [HttpGet]
        public IHttpActionResult DeleteUser(int id) //check
        {
            User user;
            using (var context = new EfDbContext())
            {
                user = context.Users.Include(u => u.Games).SingleOrDefault(u => u.Id == id);
                if (user == null)
                {
                    return NotFound();
                }
                context.Users.Remove(user);
                context.SaveChanges();

                return Ok(user);
            }
        }
    }
}
