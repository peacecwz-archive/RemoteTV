using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RemoteTV.APIClient
{
    public class DataClient
    {
        public static DataClient Instance
        {
            get
            {
                return new DataClient();
            }
        }

        public string APIUrl { get; set; } = "http://barisceviz.com";

        private HttpClient client;

        public HttpClient Client
        {
            get
            {
                if (client == null)
                    client = new HttpClient()
                    {
                        BaseAddress = new Uri(APIUrl)
                    };
                return client;
            }
            set { client = value; }
        }

        public async Task<string> GetUrl()
        {
            var request = await Client.GetAsync("/api/iot/get");
            if (!request.IsSuccessStatusCode) return null;
            return (await request.Content?.ReadAsStringAsync()).Replace(@"""", "");
        }

        public async Task Update(string Url)
        {
            var request = await Client.PostAsync("/api/iot/change", new StringContent(String.Format(@"""{0}""", Url), Encoding.UTF8, "application/json"));
        }
    }
}
