using System.Collections.Generic;
using Server.DTO;

namespace Server.Interfaces
{
    public interface IFindBestCandidateService
    {
        List<CandidateDTO> FindBestCandidates(int jobId);
    }
}
