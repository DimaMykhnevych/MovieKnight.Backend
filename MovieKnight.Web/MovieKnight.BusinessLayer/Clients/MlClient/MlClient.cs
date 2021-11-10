using MovieKnight.BusinessLayer.DTOs;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovieKnight.BusinessLayer.Clients.MlClient
{
    public class MlClient : IMlClient
    {
        private readonly HttpClient _httpClient;

        public MlClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<MlApiResponse> GetRecommendedMovieId(Guid userId)
        {
            try
            {
                var request = await _httpClient.GetAsync($"{MlApiRoutes.GetRecommendedMovie}/userId");
                var response = await request.Content.ReadAsStringAsync();
                var recommendedMovie = JsonConvert.DeserializeObject<MlApiResponse>(response);
                return recommendedMovie;
            }
            catch
            {
                return null;
            }
        }
    }
}
