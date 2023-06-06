using Target_Hunting_API.Models;

namespace Target_Hunting_API.Repositories
{
    public interface ICandidateRepository
    {
        Task<List<Candidate>> GetCandidatesAsync();
        Task AddCandidateAsync(Candidate candidate);
        Task<Candidate> GetCandidateByIdAsync(Guid id);
        Task DeleteCandidateAsync(Candidate candidate);
        Task SaveChangesAsync();

        Task<List<Candidate>> GetCandidatesByDateAndTimeAsync(string date, string time);
    }
}
