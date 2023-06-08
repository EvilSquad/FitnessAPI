using FitnessAPI.Models;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;

namespace FitnessAPI.Clients { 

    public class ExercisesClient {
        public async Task<List<Exercise>> GetExercise(string param) {
            using (var client = new HttpClient()) {
                client.DefaultRequestHeaders.Add("X-Api-Key", Constants.apikey);
                var url = $"{Constants.address}{param}";
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<Exercise>>(content);
                return result;
            }
        }
    }
}