using ProyectBlazor.Library;
using System.Net.Http.Json;
using System.Runtime.InteropServices;

namespace ProyectBlazor.Client.Services
{
    public class SrvSegUser
    {
        private readonly HttpClient _httpClient;
        public event Func<Task> OnChange;
        public List<Seg_UserCLS> ListUser { get; set; }
        public SrvSegUser(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Seg_UserCLS>> Listar_SegUser()
        {
            var Result = await _httpClient.GetFromJsonAsync<List<Seg_UserCLS>>("API/App");
            if (Result != null)
            {
                return Result;
            }
            else
            {
                return ListUser;
            }
        }

    }
}
