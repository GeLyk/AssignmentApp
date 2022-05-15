using AssignmentApp.Application.Interfaces;
using AssignmentApp.Core.Entities;
using Microsoft.AspNetCore.Mvc;


namespace AssignmentApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public MatchController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // POST: api/Match/Post
        [HttpPost("Post")]
        public ActionResult<Match> Post([FromBody] Match match)
        {
            if (match == null)
                return BadRequest("The Match is null");

            _unitOfWork.Matches.Add(match);
            _unitOfWork.Complete();

            return Ok(match);
        }

        // GET: api/Match/GetAll
        [HttpGet("GetAll")]
        public ActionResult GetAll()
        {
            var matches = _unitOfWork.Matches.GetAllWithIncludes();
            return Ok(matches);
        }

        // GET: api/Match/Get
        [HttpGet("Get")]
        public ActionResult<Match> Get(long id)
        {
            Match match = _unitOfWork.Matches.GetWithIncludes(id);

            if (match == null)
                return NotFound("Τhe match was not found.");

            return Ok(match);
        }

        // PUT: api/Match/Put
        [HttpPut("Put")]
        public ActionResult Put(long id, [FromBody] Match match)
        {
            if (id <= 0 || match == null)
                return BadRequest("The match is null.");

            Match matchDB = _unitOfWork.Matches.GetWithIncludes(id);

            if (matchDB == null)
                return NotFound("Τhe match was not found.");

            _unitOfWork.Matches.UpdateMatch(matchDB, match);
            _unitOfWork.MatchOdds.UpdateMatchOdds(matchDB, match);

            _unitOfWork.Complete();

            return Ok(match);
        }

        // DELETE: api/Match/Delete
        [HttpDelete("Delete")]
        public ActionResult Delete(long id)
        {
            Match match = _unitOfWork.Matches.Get(id);
            if (match == null)
            {
                return NotFound("Τhe match was not found.");
            }

            _unitOfWork.Matches.Delete(match);
            _unitOfWork.Complete();

            return NoContent();
        }
    }
}
