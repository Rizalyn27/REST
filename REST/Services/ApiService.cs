using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using REST.MVVM.Models;

namespace REST.MVVM.Services
{
    public class ApiService
    {
        private readonly HttpClient _http = new HttpClient();
        private const string BaseUrl = "https://69d20bad5043d95be9716536.mockapi.io/sessions";

        public async Task<List<Session>> GetAllAsync()
            => await _http.GetFromJsonAsync<List<Session>>(BaseUrl);

        public async Task<Session> GetByIdAsync(string id)
    => await _http.GetFromJsonAsync<Session>($"{BaseUrl}/{id}");

        public async Task<Session> CreateAsync(Session session)
        {
            var res = await _http.PostAsJsonAsync(BaseUrl, session);
            return await res.Content.ReadFromJsonAsync<Session>();
        }

        public async Task<Session> UpdateAsync(Session session)
        {
            var res = await _http.PutAsJsonAsync($"{BaseUrl}/{session.Id}", session);
            return await res.Content.ReadFromJsonAsync<Session>();
        }

        public async Task DeleteAsync(string id)
            => await _http.DeleteAsync($"{BaseUrl}/{id}");
    }
}