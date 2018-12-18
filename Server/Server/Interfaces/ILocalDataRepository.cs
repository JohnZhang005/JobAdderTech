using System.Collections.Generic;
using Server.Models;

namespace Server.Interfaces
{
    public interface ILocalDataRepository
    {
        List<Job> jobs { get; set; }
        List<Candidate> candidates { get; set; }
    }
}