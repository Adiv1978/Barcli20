using CliBarra.Models;
using System.Text.Json;

namespace CliBarra.Managers
{
    public static class ApiClient
    {
        public static async Task<Producto?> GetProductoAsync(string codigo)
        {
            try
            {
                if (NetworkHelper.IsInternetAvailable() == false)
                {
                    throw new ClientException("No hay conexión a internet");
                }
                var baseUrl = $"{ConfigBase.GetBaseUrl}{ConfigBase.GetEndpoint}";
                var handler = new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) => true
                };
                using (var httpClient = new HttpClient(handler))
                {
                    httpClient.DefaultRequestHeaders.Add("codigo", codigo);

                    var repuesta = await httpClient.GetAsync(baseUrl);

                    if (repuesta.IsSuccessStatusCode)
                    {
                        var jsonResponse = await repuesta.Content.ReadAsStringAsync();
                        var producto = JsonSerializer.Deserialize<Producto>(jsonResponse);
                        return producto;
                    }
                    else
                    {
                        var errorContent = await repuesta.Content.ReadAsStringAsync();
                        Console.WriteLine($"Error: {repuesta.StatusCode}, Details: {errorContent}");
                        return null;
                    }
                }
            }
            catch (ClientException ex)
            {
                throw new ClientException(ex.Message);
            }
            catch(Exception ex)
            {
                throw new Exception("Error de conexion" + ex.Message);
            }
        }
    }
}
