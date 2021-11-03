using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnetCoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace aspnetCoreAPI.Data
{
    public class FilmContext : DbContext
    {
        // Extende ao construtor da classe pai.
        public FilmContext(DbContextOptions<FilmContext> opt) : base (opt)
        {

        }

        public DbSet<Film> Films { get; set; }
    }
}