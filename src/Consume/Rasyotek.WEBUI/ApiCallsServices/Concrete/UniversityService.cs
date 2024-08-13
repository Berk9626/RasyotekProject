using Newtonsoft.Json;
using Rasyotek.WEBUI.ApiCallsServices.Abstract;
using System.Net.Http;

namespace Rasyotek.WEBUI.ApiCallsServices.Concrete
{
    public class UniversityService : IUniversityService
    {
        private readonly HttpClient _httpClient;

        public UniversityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task < List<string>> GetUniversitiesAsync()
        {
            var response =await  _httpClient.GetStringAsync("http://universities.hipolabs.com/search?country=Turkey");
            var univercities = JsonConvert.DeserializeObject<List<University>>(response);

            return univercities.Select(u => u.Name).ToList();
        }

        public class University
        {
            public string Name { get; set; }
        }
    }
}
