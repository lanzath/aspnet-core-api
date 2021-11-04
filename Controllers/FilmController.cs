using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnetCoreAPI.Data;
using aspnetCoreAPI.Data.Dtos;
using aspnetCoreAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace aspnetCoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmController : ControllerBase
    {
        private FilmContext _context;
        private IMapper _mapper;

        public FilmController(FilmContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult NewFilm([FromBody] CreateFilmDto filmDto)
        {
            // Converte de FilmDto para Film.
            Film film = _mapper.Map<Film>(filmDto);
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
            if (film != null)
            {
                ReadFilmDto filmDto = _mapper.Map<ReadFilmDto>(film);
                return Ok(filmDto);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFilm(int id, [FromBody] UpdateFilmDto filmDto)
        {
            var film = _context.Films.FirstOrDefault(film => film.Id == id);
            if (film == null) return NotFound();

            // Sobreescreve film com as informações de filmDto.
            _mapper.Map(filmDto, film);
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
