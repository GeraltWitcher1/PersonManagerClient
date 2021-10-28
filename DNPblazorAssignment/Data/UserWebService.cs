using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Models;

namespace DNPblazorAssignment.Data
{
    public class UserWebService : IUserService
    {
        public async Task<User> ValidateUser(string username, string password)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage =
                await client.GetAsync($"https://localhost:5001/User?username={username}&password={password}");

            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");

            string result = await responseMessage.Content.ReadAsStringAsync();

            User user = JsonSerializer.Deserialize<User>(result,new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return user;
        }
        
    }
}