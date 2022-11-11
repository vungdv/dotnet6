using airproject.domain.Application.Ports.Outbound;
using airproject.domain.Domain;
using airproject.providers.openair.Models;
using RestSharp;
using System.Text.Json;

namespace airproject.providers.openair
{
    public class OpenAirProvider : IAirConditionRepository
    {
        public IEnumerable<Location> GetLocations(string city, string sort, int page, int pageSize)
        {
            var client = new RestClient("https://api.openaq.org/v2/");
            var request = new RestRequest($"locations?limit={pageSize}&page={page}&offset=0&sort={sort}&radius=1000&city={city}&order_by=lastUpdated&dumpRaw=false", Method.Get);
            request.AddHeader("accept", "application/json");
            var response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK && !string.IsNullOrWhiteSpace(response.Content))
            {
                var result = JsonSerializer.Deserialize<Response<Location>>(
                    response.Content,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                return result.results;
            }
            return Enumerable.Empty<Location>();
        }
    }
}