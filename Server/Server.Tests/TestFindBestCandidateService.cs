using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server.Models;
using Server.Services;

namespace Server.Tests
{
    [TestClass]
    public class TestFindBestCandidateService
    {
        [TestMethod]
        public void FindBestCandidates_JobSkill()
        {
            List<Job> jobs = new List<Job>();
            List<Candidate> candidates = new List<Candidate>();

            jobs.Add(new Job { JobId = 1, Name = "Reception", Company = "Surile", Skills = "detail, ms-office, word" });
            candidates.Add(new Candidate { CandidateId = 1, Name = "Ahan Bravo", SkillTags = "detail" });
            candidates.Add(new Candidate { CandidateId = 2, Name = "Bhan Bravo", SkillTags = "ms-office" });
            candidates.Add(new Candidate { CandidateId = 3, Name = "Chan Bravo", SkillTags = "word" });
            candidates.Add(new Candidate { CandidateId = 4, Name = "Dhan Bravo", SkillTags = "other" });

            TestLocalRepository dbRepository = new TestLocalRepository(jobs, candidates);
            FindBestCandidateService findCandidateService = new FindBestCandidateService(dbRepository);

            var result = findCandidateService.FindBestCandidates(1);
            Assert.AreEqual(result[0].CandidateId, 1);
        }

        [TestMethod]
        public void TestMethod2()
        {
            List<Job> jobs = new List<Job>();
            List<Candidate> candidates = new List<Candidate>();

            jobs.Add(new Job { JobId = 1, Name = "Reception", Company = "Surile", Skills = "detail, ms-office, word" });
            candidates.Add(new Candidate { CandidateId = 1, Name = "Ahan Bravo", SkillTags = "detail" });
            candidates.Add(new Candidate { CandidateId = 2, Name = "Bhan Bravo", SkillTags = "other, detail" });
            candidates.Add(new Candidate { CandidateId = 3, Name = "Chan Bravo", SkillTags = "other, other, detail" });

            TestLocalRepository dbRepository = new TestLocalRepository(jobs, candidates);
            FindBestCandidateService findCandidateService = new FindBestCandidateService(dbRepository);

            var result = findCandidateService.FindBestCandidates(1);
            Assert.AreEqual(result[0].CandidateId, 1);
        }

        [TestMethod]
        public void TestMethod3()
        {
            List<Job> jobs = new List<Job>();
            List<Candidate> candidates = new List<Candidate>();

            jobs.Add(new Job { JobId = 1, Name = "Reception", Company = "Surile", Skills = "detail, ms-office, word" });
            candidates.Add(new Candidate { CandidateId = 1, Name = "Ahan Bravo", SkillTags = "detail, ms-office, word" });
            candidates.Add(new Candidate { CandidateId = 2, Name = "Bhan Bravo", SkillTags = "detail, ms-office, other" });
            candidates.Add(new Candidate { CandidateId = 3, Name = "Chan Bravo", SkillTags = "detail, other, other" });
            candidates.Add(new Candidate { CandidateId = 4, Name = "Dhan Bravo", SkillTags = "other, other, other" });

            TestLocalRepository dbRepository = new TestLocalRepository(jobs, candidates);
            FindBestCandidateService findCandidateService = new FindBestCandidateService(dbRepository);

            var result = findCandidateService.FindBestCandidates(1);
            Assert.AreEqual(result[0].CandidateId, 1);
        }

        [TestMethod]
        public void TestMethod4()
        {
            List<Job> jobs = new List<Job>();
            List<Candidate> candidates = new List<Candidate>();

            jobs.Add(new Job { JobId = 1, Name = "Reception", Company = "Surile", Skills = "detail, ms-office, word" });
            candidates.Add(new Candidate { CandidateId = 1, Name = "Ahan Bravo", SkillTags = "detail, ms-office, word" });
            candidates.Add(new Candidate { CandidateId = 2, Name = "Bhan Bravo", SkillTags = "detail, word, ms-office" });
            candidates.Add(new Candidate { CandidateId = 3, Name = "Chan Bravo", SkillTags = "ms-office, detail, word" });
            candidates.Add(new Candidate { CandidateId = 4, Name = "Dhan Bravo", SkillTags = "ms-office, word, detail" });
            candidates.Add(new Candidate { CandidateId = 5, Name = "Ehan Bravo", SkillTags = "word, detail, ms-office" });
            candidates.Add(new Candidate { CandidateId = 6, Name = "Fhan Bravo", SkillTags = "word, ms-office, detail" });

            TestLocalRepository dbRepository = new TestLocalRepository(jobs, candidates);
            FindBestCandidateService findCandidateService = new FindBestCandidateService(dbRepository);

            var result = findCandidateService.FindBestCandidates(1);
            Assert.AreEqual(result[0].CandidateId, 1);
        }
    }
}
