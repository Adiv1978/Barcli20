using System.Net.NetworkInformation;

namespace CliBarra.Managers
{
    public static class NetworkHelper
    {
        public static bool IsInternetAvailable()
        {
            return Connectivity.Current.NetworkAccess == NetworkAccess.Internet;
        }

        public static async Task<bool> IsServerAvailableAsync(string host)
        {
            try
            {
                using var ping = new Ping();
                var reply = await ping.SendPingAsync(host, 1000);
                return reply.Status == IPStatus.Success;
            }
            catch
            {
                return false;
            }
        }

        public static async Task<bool> IsServiceAvailableAsync(string url)
        {
            try
            {
                using var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(url);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}
