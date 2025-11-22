using API.P.Movies.DAL.Models;
using API.P.Movies.DAL.Models.Dtos;
using AutoMapper;

namespace API.P.Movies.MoviesMapper
{
    public class Mappers : Profile
    {
        public Mappers()
        {
            // category mappings
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryCreateUpdateDto>().ReverseMap();

            // movie mappings
            CreateMap<Movie, MovieDto>().ReverseMap();
            CreateMap<Movie, MovieCreateUpdateDto>().ReverseMap();
        }
    }
}
