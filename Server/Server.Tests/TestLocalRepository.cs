using System.Collections.Generic;
using Server.Interfaces;
using Server.Models;

namespace Server.Tests
{
    class TestLocalRepository : ILocalDataRepository
    {
        public List<Job> jobs { get; set; }
        public List<Candidate> candidates { get; set; }

        public TestLocalRepository(List<Job> jobList, List<Candidate> candidateList)
        {
            jobs = jobList;
            candidates = candidateList;
        }
    }
}
