﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laborator11.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Laborator11.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private MoviesDbContext context;

        public MoviesController(MoviesDbContext context) {
            this.context = context;
        }


        // GET: api/Movies
        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return context.Movies;
        }

        // GET: api/Movies/5
        [HttpGet("{id}", Name = "Get")]
        public Movie Get(int id)
        {
            return context.Movies.FirstOrDefault(c => c.Id == id);

        }

        // POST: api/Movies
        [HttpPost]
        public IActionResult Post([FromBody] Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Movies.Add(movie);
            context.SaveChanges();
            return Ok();
        }

        // PUT: api/Movies/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existing = context.Movies.FirstOrDefault(c => c.Id == id);
            if (existing != null)
            {
                movie.Id = existing.Id;
                context.Movies.Remove(existing);
            }
            context.Movies.Add(movie);
            context.SaveChanges();
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var found = context.Movies.FirstOrDefault(c => c.Id == id);
            if (found == null)
            {
                return NotFound();
            }
            context.Movies.Remove(found);
            context.SaveChanges();
            return Ok();
        }
    }
}
