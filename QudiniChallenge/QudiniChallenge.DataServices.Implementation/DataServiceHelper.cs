using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using QudiniChallenge.Contracts.DataServices;
using QudiniChallenge.Global;

namespace QudiniChallenge.DataServices.Implementation
{
    public class DataServiceHelper
    {
        public static async Task<DataResult<T>> DoGetWithAuth<T>(string url, ILoginCredentials credentials)
        {
            try
            {
                var client = GetClient();
                var byteArray = Encoding.UTF8.GetBytes(string.Format("{0}:{1}", credentials.Username, credentials.Password));
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                var res = await client.GetAsync(url);
                if (res.IsSuccessStatusCode)
                {
                    var resString = await res.Content.ReadAsStringAsync();
                    return new DataResult<T>(JsonConvert.DeserializeObject<T>(resString));
                }
                if (res.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return new DataResult<T>(Result.InvalidCredentials);
                }
                return new DataResult<T>(Result.Error, res.ReasonPhrase);
            }
            catch (Exception e)
            {
                return new DataResult<T>(Result.Error, e.Message);
            }
        }

        private static HttpClient GetClient()
        {
            var handler = new HttpClientHandler()
            {
                AllowAutoRedirect = false
            };

            return  new HttpClient(handler);
        }
    }
}