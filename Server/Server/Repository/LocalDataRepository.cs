using System.Collections.Generic;
using System.IO;
using System.Web.Hosting;
using Newtonsoft.Json;
using Server.Models;
using Server.Interfaces;

namespace Server.Repository
{
    public class LocalDataRepository : ILocalDataRepository
    {
        private const string JOB_FILE = @"~/App_Data/JobJSON.txt";
        private const string CANDIDATE_FILE = @"~/App_Data/CandidateJSON.txt";

        public List<Job> jobs { get; set; }
        public List<Candidate> candidates { get; set; }

        public LocalDataRepository()
        {
            jobs = JsonConvert.DeserializeObject<List<Job>>(File.ReadAllText(HostingEnvironment.MapPath(JOB_FILE)));
            candidates = JsonConvert.DeserializeObject<List<Candidate>>(File.ReadAllText(HostingEnvironment.MapPath(CANDIDATE_FILE)));
        }
    }
}