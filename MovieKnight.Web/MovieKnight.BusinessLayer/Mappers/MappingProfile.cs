using AutoMapper;
using MovieKnight.BusinessLayer.DTOs;
using MovieKnight.BusinessLayer.Extensions;
using MovieKnight.DataLayer.Models;

namespace MovieKnight.BusinessLayer.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserDto, AppUser>()
            .IgnoreAllUnmapped()
            .ForMember(u => u.Role, m => m.MapFrom(u => u.Role))
            .ForMember(u => u.UserName, m => m.MapFrom(u => u.Username));

            CreateMap<AddMovieDto, Movie>().ReverseMap();
            CreateMap<MovieDto, Movie>().ReverseMap();
        }
    }
}
