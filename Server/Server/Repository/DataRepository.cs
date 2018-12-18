using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Server.Models;

namespace Server.Repository
{
    public class DataRepository
    {
        private const string JOB_URL = "http://private-76432-jobadder1.apiary-mock.com/jobs";
        private const string CANDIDATE_URL = "http://private-76432-jobadder1.apiary-mock.com/candidates";

        public static async Task<List<Job>> LoadJobs()
        {
            return JsonConvert.DeserializeObject<List<Job>>(await GetAPIJson(JOB_URL));
        }

        public static async Task<List<Candidate>> LoadCandidates()
        {
            return JsonConvert.DeserializeObject<List<Candidate>>(await GetAPIJson(CANDIDATE_URL));
        }

        private static async Task<string> GetAPIJson(string url)
        {
            string result = "";
            using (var client = new HttpClient()) {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode) {
                    result = await response.Content.ReadAsStringAsync();
                }
            }
            return result;
        }
    }
}