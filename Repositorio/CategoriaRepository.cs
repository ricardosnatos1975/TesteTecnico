using System.Net.Http.Json;
using TesteTecnico.Models;

namespace TesteTecnico.Repositorio
{
    public class CategoriaRepositorio
    {
        private readonly HttpClient _httpClient;
        private const string ApiUrl = "api/categoria";

        public CategoriaRepositorio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Categoria>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<List<Categoria>>(ApiUrl);
        }

        public async Task<Categoria> GetById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Categoria>($"{ApiUrl}/{id}");
        }

        public async Task<Categoria> Create(Produto produto)
        {
            var response = await _httpClient.PostAsJsonAsync(ApiUrl, produto);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Categoria>();
            }

            return null;
        }

        public async Task<Categoria> Update(int id, Produto produto)
        {
            var response = await _httpClient.PutAsJsonAsync($"{ApiUrl}/{id}", produto);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Categoria>();
            }

            return null;
        }

        public async Task<bool> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"{ApiUrl}/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
