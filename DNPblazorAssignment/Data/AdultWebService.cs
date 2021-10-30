using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Models;

namespace DNPblazorAssignment.Data
{
    public class AdultWebService : IAdultService
    {

        private readonly HttpClient client;
        private const string Uri = "https://localhost:5001";
        
        public AdultWebService()
        {
            client = new HttpClient();
        }
        
        public async Task AddAdult(Adult adult)
        {
            string adultAsJson = JsonSerializer.Serialize(adult);
            StringContent content = new StringContent(
                adultAsJson,
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage responseMessage = await client.PostAsync(Uri + "/adults", content);
            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
        }

        public async Task RemoveAdult(int id)
        {
            HttpResponseMessage responseMessage = await client.DeleteAsync(Uri + $"/adults/{id}");
            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
        }

        public async Task UpdateAdult(Adult adult)
        {
            string adultAsJson = JsonSerializer.Serialize(adult);
            StringContent content = new(
                adultAsJson,
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage responseMessage = await client.PatchAsync(Uri + $"/adults/{adult.Id}", content);
            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
        }

        public async Task<Adult> GetAdult(int id)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(Uri + $"/adults?id={id}"),
            };
            using var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            Console.WriteLine(body);

            IList<Adult> adults = JsonSerializer.Deserialize<IList<Adult>>(body,new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return adults?[0];
        }

        public async Task<IList<Adult>> GetAll()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(Uri+"/Adults"),
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                
                IList<Adult> adults = JsonSerializer.Deserialize<IList<Adult>>(body,new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
                return adults;
            }
        }
    }
}