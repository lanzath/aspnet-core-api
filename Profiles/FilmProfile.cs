using aspnetCoreAPI.Data.Dtos;
using aspnetCoreAPI.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetCoreAPI.Profiles
{
    public class FilmProfile : Profile
    {
        public FilmProfile()
        {
            // AutoMapper converte de um tipo para outro.
            CreateMap<CreateFilmDto, Film>();
            CreateMap<Film, ReadFilmDto>();
            CreateMap<UpdateFilmDto, Film>();
        }
    }
}