using Server.Models;

namespace Server.DTO
{
    public class CandidateDTO : Candidate
    {
        public float JobMatchScore { get; set; }
        public float SkillMatchPercentage { get; set; }

        public CandidateDTO(Candidate candidate, float matchScore, float matchPercentage)
        {
            CandidateId = candidate.CandidateId;
            Name = candidate.Name;
            SkillTags = candidate.SkillTags;
            JobMatchScore = matchScore;
            SkillMatchPercentage = matchPercentage;
        }
    }
}