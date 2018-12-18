using System;
using System.Collections.Generic;
using System.Linq;
using Server.DTO;
using Server.Interfaces;
using Server.Models;

namespace Server.Services
{
    public class FindBestCandidateService : IFindBestCandidateService
    {
        private ILocalDataRepository _repository;
        public FindBestCandidateService(ILocalDataRepository repository)
        {
            _repository = repository;
        }

        public List<CandidateDTO> FindBestCandidates(int jobId)
        {
            Job job = _repository.jobs.FirstOrDefault(j => j.JobId == jobId);

            if (job == null)
                return null;

            List<Candidate> candidates = _repository.candidates;
            List<CandidateDTO> result = new List<CandidateDTO>();

            foreach (Candidate candidate in candidates) {
                List<string> jobRequirements = GetSkillList(job.Skills);
                List<string> candidateSkills = GetSkillList(candidate.SkillTags);
                float matchPercentage = ComputeMatchPercentage(jobRequirements, candidateSkills);
                if (matchPercentage != 0f) {
                    float matchScore = ComputeMatchScore(jobRequirements, candidateSkills);
                    result.Add(new CandidateDTO(candidate, matchScore, matchPercentage));
                }
            }

            return result.OrderByDescending(a => a.JobMatchScore).ToList();
        }

        private float ComputeMatchScore(List<string> requirements, List<string> skillTags)
        {
            List<string> matchSkills = requirements.Intersect(skillTags).ToList();

            double score = 0f;
            foreach (string skill in matchSkills) {
                int indexRequirement = requirements.IndexOf(skill);
                int indexCandidate = skillTags.IndexOf(skill);

                double weight = Math.Pow(2, requirements.Count - indexRequirement - 1);
                int weakness = indexCandidate > indexRequirement ? indexCandidate - indexRequirement : 0;

                if (weakness != 0) {
                    weight *= Math.Pow(0.9, weakness);
                }
                score += weight;
            }
            score /= Math.Pow(2, requirements.Count) - 1;
            return (float)score;
        }

        private float ComputeMatchPercentage(List<string> requirements, List<string> skillTags)
        {
            return (float)requirements.Intersect(skillTags).Count() / (float)requirements.Count;
        }

        private List<string> GetSkillList(string skills)
        {
            return skills.Split(',').Select(s => s.Trim()).ToList();
        }
    }
}