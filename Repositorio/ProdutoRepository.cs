using System.Net.Http.Json;
using TesteTecnico.Models;

namespace TesteTecnico.Repositorio
{
    public class ProdutoRepositorio
    {
        private readonly HttpClient _httpClient;
        private const string ApiUrl = "api/produtos";

        public ProdutoRepositorio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Produto>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<List<Produto>>(ApiUrl);
        }

        public async Task<Produto> GetById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Produto>($"{ApiUrl}/{id}");
        }

        public async Task<Produto> Create(Produto produto)
        {
            var response = await _httpClient.PostAsJsonAsync(ApiUrl, produto);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Produto>();
            }

            return null;
        }

        public async Task<Produto> Update(int id, Produto produto)
        {
            var response = await _httpClient.PutAsJsonAsync($"{ApiUrl}/{id}", produto);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Produto>();
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
