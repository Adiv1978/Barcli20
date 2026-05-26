namespace CliBarra.Models
{
    public static class ConfigBase
    {
        public static string GetBaseUrl
        {
            get
            {
                return "http://172.16.16.8:8085";
            }
        }
        public static string GetEndpoint
        {
            get
            {
                return "/api/Producto/GetProducto";
            }
        }
    }
}
