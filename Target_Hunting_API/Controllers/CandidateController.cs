using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Target_Hunting_API.Database;
using Target_Hunting_API.Models;
using Target_Hunting_API.Repositories;

namespace Target_Hunting_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateRepository candidateRepository;

        public CandidateController(ICandidateRepository candidateRepository)
        {
            this.candidateRepository = candidateRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCandidate()
        {
            try
            {
                var candidates = await candidateRepository.GetCandidatesAsync();
                return Ok(candidates);
            }
            catch (Exception ex)
            {
              
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching candidates.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCandidate([FromBody] Candidate cnd)
        {
            try
            {
                cnd.Id = Guid.NewGuid();
                await candidateRepository.AddCandidateAsync(cnd);
                return Ok(cnd);
            }
            catch (Exception ex)
            {
               
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating candidate.");
            }
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateCandidate([FromRoute] Guid id, [FromBody] Candidate cnd)
        {
            try
            {
                var candidate = await candidateRepository.GetCandidateByIdAsync(id);
                if (candidate != null)
                {
                    candidate.Name = cnd.Name;
                    candidate.Email = cnd.Email;
                    candidate.MobileNo = cnd.MobileNo;
                    candidate.Position = cnd.Position;
                    candidate.Date = cnd.Date;
                    candidate.Time = cnd.Time;
                    await candidateRepository.SaveChangesAsync();
                    return Ok(cnd);
                }
                else
                {
                    return NotFound("Candidate not found");
                }
            }
            catch (Exception ex)
            {
              
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating candidate.");
            }
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteCandidate([FromRoute] Guid id)
        {
            try
            {
                var candidate = await candidateRepository.GetCandidateByIdAsync(id);
                if (candidate != null)
                {
                    await candidateRepository.DeleteCandidateAsync(candidate);
                    return Ok(candidate);
                }
                else
                {
                    return NotFound("Candidate not found");
                }
            }
            catch (Exception ex)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting candidate.");
            }
        }
    }
}
