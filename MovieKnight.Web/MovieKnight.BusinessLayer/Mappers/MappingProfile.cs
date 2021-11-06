using AutoMapper;
using MovieKnight.BusinessLayer.DTOs;
using MovieKnight.BusinessLayer.Extensions;
using MovieKnight.BusinessLayer.Resolvers;
using MovieKnight.DataLayer.Models;

namespace MovieKnight.BusinessLayer.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserDto, AppUser>()
            .ForMember(u => u.Role, m => m.MapFrom(u => u.Role))
            .ForMember(u => u.UserName, m => m.MapFrom(u => u.Username));

            CreateMap<UpdateUserDto, AppUser>()
                   .IgnoreAllUnmapped()
                   .ForMember(u => u.UserName, m => m.MapFrom(u => u.Username))
                   .ForMember(u => u.StoryVisibility, m => m.MapFrom(u => u.StoryVisibility))
                   .ForMember(u => u.BirthdayDate, m => m.MapFrom(u => u.BirthdayDate));

            CreateMap<AddMovieDto, Movie>().ReverseMap();

            CreateMap<Movie, MovieDto>().ForMember(mdto => mdto.MovieInfo,
                mdto => mdto.MapFrom<FullMovieInfoResolver>());
            CreateMap<WatchHistory, WatchHistoryDto>().ForMember(wdto => wdto.Movie,
                wdto => wdto.MapFrom<WatchHistoryMovieResolver>());

            CreateMap<AddWatchHistoryDto, WatchHistory>().ReverseMap();
            CreateMap<FriendRequest, FriendRequestDto>().ReverseMap();
            CreateMap<FriendsDto, Friends>().ReverseMap();
            CreateMap<AddFriendRequestDto, FriendRequest>().ReverseMap();
            CreateMap<UpdateRequestDto, FriendRequest>().ReverseMap();
            CreateMap<CommentDto, Comment>().ReverseMap();
        }
    }
}
