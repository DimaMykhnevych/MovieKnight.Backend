using MovieKnight.BusinessLayer.DTOs;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MovieKnight.BusinessLayer.Options;
using Microsoft.Extensions.Options;

namespace MovieKnight.BusinessLayer.Clients.MovieClient
{
    public class ImdbMovieClient : IImdbMovieClient
    {
        private readonly HttpClient _httpClient;
        private readonly IMDbApiDetails _iMDbApiDetails;

        public ImdbMovieClient(HttpClient httpClient, IOptions<IMDbApiDetails> options)
        {
            _httpClient = httpClient;
            _iMDbApiDetails = options.Value;
        }

        public async Task<MovieModel> GetMovieFromImdb(string imdbMovieId)
        {
            var parameters = new Dictionary<string, string> { { "lang", "en"}, { "apiKey", _iMDbApiDetails.IMDbApiKey }, { "id", imdbMovieId } };
            var apiRoute = GetFullApiRoute(parameters, ImdbApiRoutes.GetMovieById);

            try
            {
                var request = await _httpClient.GetAsync(apiRoute);
                var response = await request.Content.ReadAsStringAsync();
                var movieInfo = JsonConvert.DeserializeObject<MovieModel>(response);
                return movieInfo;
            }
            catch
            {
                return null;
            }
        }

        private string GetFullApiRoute(Dictionary<string, string> parameters, string templateRoute)
        {
            return Regex.Replace(templateRoute, @"\{(.+?)\}", m => parameters[m.Groups[1].Value]);
        }
    }
}
