using KanbanApp.Blazor.DTOs;
using System.Text.Json;

namespace KanbanApp.Blazor.Services
{
    public class LocationApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "http://localhost:5294/api";

        public LocationApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<RackDto>> GetAllRacksAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}/Location/all-rack");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var json = JsonSerializer.Deserialize<IEnumerable<RackDto>>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return json ?? Enumerable.Empty<RackDto>(); // Zwraca pustą listę, jeśli `json` jest null
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching racks: {ex.Message}");
                return Enumerable.Empty<RackDto>(); // Zwraca pustą listę w razie błędu
            }
        }
    }
}
