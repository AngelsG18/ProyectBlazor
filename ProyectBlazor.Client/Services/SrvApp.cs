using ProyectBlazor.Library;
using System.Net.Http.Json;
using System.Runtime.InteropServices;
namespace ProyectBlazor.Client.Services
{
    public class SrvApp
    {
        private readonly HttpClient _httpClient;
        public event Func<Task> OnChange;
        public event Func<AplicacionCLS, Task> OnEdit;
        public List<AplicacionCLS> ListaApp { get; set; }
        public SrvApp(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }
        public async Task<List<AplicacionCLS>> listarApp()
        {
            var result = await _httpClient.GetFromJsonAsync<List<AplicacionCLS>>("API/App");
            if (result != null)
            {
                return result;
            }
            else
            {
                return ListaApp;
            }
        }

        public void AgregarApp(AplicacionCLS sAplicacionCLS) 
        {
            ListaApp.Add(sAplicacionCLS);
            CargaGrilla();
        }
        public void EliminarApp(String cod_app)
        {
            AplicacionCLS app = ListaApp.Where(p => p.Cod_aplicacion == cod_app).First();
            ListaApp.Remove(app);
            CargaGrilla();
        }
        
        public void CargaGrilla()
        {
            OnChange?.Invoke();
        }

        public void CargaGrillaEdit(AplicacionCLS sAplicacionCLS)
        {
            OnEdit?.Invoke(sAplicacionCLS);
        }

        public AplicacionCLS RecuperaApp(string codApp)
        {
            return ListaApp.Where(p => p.Cod_aplicacion == codApp).First();
        }

    }
}
