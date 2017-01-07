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
    [RoutePrefix("api/Games")]
    public class GameController : ApiController
    {
        [Route("GetAll")]
        [HttpGet]
        public IHttpActionResult GetAllGames() //check
        {
            IEnumerable<Game> games;
            using (var context = new EfDbContext())
            {
                games = context.Games.ToList();
            }
            return Ok(games);
        }

        [Route("GetGame/{id:int}")]
        [HttpGet]
        public IHttpActionResult GetGame(int id) //check
        {
            Game game;
            using (var context = new EfDbContext())
            {
                game = context.Games.SingleOrDefault(g => g.Id == id);
            }
            return Ok(game);
        }

        // POST: api/Game 
        [HttpGet]
        public IHttpActionResult PostGame([FromBody]Game game) //nawet nie wiem jak sprawdzic :)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (var context = new EfDbContext())
            {
                context.Games.Add(game);
                context.SaveChanges();
            }

            return CreatedAtRoute("GetStudent", new { id = game.Id }, game);
        }

        // PUT: api/Game/5
        [HttpGet]
        public IHttpActionResult PutGame(int id, [FromBody]Game game) //tego też nie :)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != game.Id)
            {
                return BadRequest();
            }
            using (var context = new EfDbContext()) try
                {
                    context.Entry(game).State = EntityState.Modified;
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (game == null)
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

        [Route("DeleteGame/{id:int}")]
        [HttpGet]
        public IHttpActionResult DeleteGame(int id) //check
        {
            Game game;
            using (var context = new EfDbContext())
            {
                game = context.Games.SingleOrDefault(g => g.Id == id);
                if (game == null)
                {
                    return NotFound();
                }
                context.Games.Remove(game);
                context.SaveChanges();

                return Ok(game);
            }
        }
    }
}
