using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnetCoreAPI.Data;
using aspnetCoreAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace aspnetCoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmController : ControllerBase
    {
        private FilmContext _context;

        public FilmController(FilmContext context) => _context = context;

        [HttpPost]
        public IActionResult NewFilm([FromBody] Film film)
        {
            _context.Films.Add(film);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetFilm), new { Id = film.Id }, film);
        }

        [HttpGet]
        public IEnumerable<Film> ListFilms() => _context.Films;

        [HttpGet("{id}")]
        public IActionResult GetFilm(int id)
        {
            var film = _context.Films.FirstOrDefault(film => film.Id == id);
            if (film != null) return Ok(film);

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFilm(int id, [FromBody] Film updatedFilm)
        {
            var film = _context.Films.FirstOrDefault(film => film.Id == id);
            if (film == null) return NotFound();

            film.Title = updatedFilm.Title;
            film.Genre = updatedFilm.Genre;
            film.Director = updatedFilm.Director;
            film.Length = updatedFilm.Length;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFilm(int id)
        {
            var film = _context.Films.FirstOrDefault(film => film.Id == id);
            if (film == null) return NotFound();

            _context.Remove(film);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
