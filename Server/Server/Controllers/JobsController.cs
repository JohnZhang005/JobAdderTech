using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Server.Interfaces;

namespace Server.Controllers
{
    [EnableCors("*", "*", "*")]
    public class JobsController : ApiController
    {
        private const int PAGE_SIZE = 5;

        private ILocalDataRepository _repository;
        private IFindBestCandidateService _candidateFinder;

        public JobsController(ILocalDataRepository repository, IFindBestCandidateService candidateFinder)
        {
            _repository = repository;
            _candidateFinder = candidateFinder;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            try {
                var jobs = _repository.jobs;
                return Ok(new { jobs });
            } catch (Exception e) {
                return null;
            }
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try {
                return Ok(new { candidates = _candidateFinder.FindBestCandidates(id) });
            } catch (Exception e) {
                return BadRequest(e.ToString());
            }
        }

        [HttpGet]
        public IHttpActionResult Get(int id, int page)
        {
            try {
                var query = _candidateFinder.FindBestCandidates(id);
                var totalPages = Math.Ceiling((double)query.Count / PAGE_SIZE);

                if (page > totalPages)
                    return BadRequest("Invalid page number.");
                var results = query.Skip(PAGE_SIZE * (page - 1))
                                   .Take(PAGE_SIZE)
                                   .ToList();
                return Ok(new {
                    totalPages,
                    page,
                    candidates = results
                });
            } catch (Exception e) {
                return BadRequest(e.ToString());
            }
        }
    }
}
