using MovieKnight.BusinessLayer.DTOs;
using System;
using System.Threading.Tasks;

namespace MovieKnight.BusinessLayer.Clients.MlClient
{
    public interface IMlClient
    {
        Task<MlApiResponse> GetRecommendedMovieId(string username);
    }
}
