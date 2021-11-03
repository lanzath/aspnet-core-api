using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnetCoreAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace aspnetCoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmController : ControllerBase
    {
        private static List<Film> Films = new List<Film>();
        private static int id = 1;

        [HttpPost]
        public IActionResult NewFilm([FromBody] Film film)
        {
            film.Id = id++;
            Films.Add(film);

            // Ao criar indica o nome do método que recupera o registro no headers
            // E devolve o registro criado com status 201.
            return CreatedAtAction(
                nameof(GetFilm),
                new { Id = film.Id },
                film
            );
        }

        [HttpGet]
        public IActionResult ListFilms() => Ok(Films);

        [HttpGet("{id}")]
        public IActionResult GetFilm(int id)
        {
            var film = Films.FirstOrDefault(film => film.Id == id);
            if (film != null) return Ok(film);

            return NotFound();
        }
    }
}
