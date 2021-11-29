using MovieKnight.BusinessLayer.DTOs;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MovieKnight.BusinessLayer.Options;
using Microsoft.Extensions.Options;
using System.Linq;

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
            int index = 0;
            var keys = _iMDbApiDetails.IMDbApiKey.ToArray();
            while (true)
            {
                var parameters = new Dictionary<string, string> {
                { "lang", "en"},
                { "apiKey", keys[index] },
                { "id", imdbMovieId }
             };
                var apiRoute = GetFullApiRoute(parameters, ImdbApiRoutes.GetMovieById);

                try
                {
                    var request = await _httpClient.GetAsync(apiRoute);
                    var response = await request.Content.ReadAsStringAsync();
                    var movieInfo = JsonConvert.DeserializeObject<MovieModel>(response);
                    if(movieInfo.ErrorMessage.Length > 0)
                    {
                        index++;
                    }
                    else
                    {
                        return movieInfo;
                    }
                }
                catch
                {
                    return null;
                }
            }
        }

        private string GetFullApiRoute(Dictionary<string, string> parameters, string templateRoute)
        {
            return Regex.Replace(templateRoute, @"\{(.+?)\}", m => parameters[m.Groups[1].Value]);
        }
    }
}
