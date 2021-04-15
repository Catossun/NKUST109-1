using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace KHLightTrail
{
    public class VolumeDataset
    {
        private const string DATA_URL = "https://data.kcg.gov.tw/dataset/6f29f6f4-2549-4473-aa90-bf60d10895dc/resource/30dfc2cf-17b5-4a40-8bb7-c511ea166bd3/download/lightrailtraffic.json";

        public static Task<List<VolumeData>> GetAllVolumes()
        {
            return Task.Run(() =>
            {
                HttpClient client = new HttpClient()
                {
                    BaseAddress = new Uri(DATA_URL)
                };
                HttpResponseMessage response = client.GetAsync("").Result;
                string body = response.Content.ReadAsStringAsync().Result;
                List<VolumeData> result = JsonSerializer.Deserialize<List<VolumeData>>(body);
                return result;
            });
        }
    }
}