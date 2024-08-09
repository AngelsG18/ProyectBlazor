using ProyectBlazor.Library;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.InteropServices;

namespace ProyectBlazor.Client.Services
{
    public class SrvOpciones
    {
        private readonly HttpClient _httpClient;
        public List<OpcionesCLS> ListaOpcion;
        public event Func<Task> OnChange;
        public event Func<OpcionesCLS, Task> OnEdit;
        public event Func<string, Task> OnTitle;
        public SrvOpciones(HttpClient httpClient) {  _httpClient = httpClient; }
        public async Task<List<OpcionesCLS>> ListarOpciones()
        {
            var result = await _httpClient.GetFromJsonAsync<List<OpcionesCLS>>("API/Opcion");
            if (result != null)
            {
                return result;
            }
            else
            {
                return ListaOpcion;
            }
        }

        public void AgregarOpcion(OpcionesCLS opcion)
        {
            ListaOpcion.Add(opcion);
            CargaGrid();
        }

        public void CargaGrid()
        {
            OnChange?.Invoke();
        }
            
        public void EliminarOpcion(string cod_opcion)
        {
            OpcionesCLS sOpcionesCLS = ListaOpcion.Where(p => p.Cod_Opcion == cod_opcion).First();
            ListaOpcion.Remove(sOpcionesCLS);
            CargaGrid();
        }
        public void NotificarGrid(OpcionesCLS sOpcionesCls)
        {
            OnEdit?.Invoke(sOpcionesCls);
        }
        public void NotificarTitle(string TitleOpcion)
        {
            OnTitle?.Invoke(TitleOpcion);
        }

    }
}
