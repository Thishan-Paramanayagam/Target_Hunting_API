using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Target_Hunting_API.Database;
using Target_Hunting_API.Models;

namespace Target_Hunting_API.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly CandidateDbContext _context;

        public CandidateRepository(CandidateDbContext context)
        {
            _context = context;
        }

        public async Task<List<Candidate>> GetCandidatesAsync()
        {
            return await _context.Candidates.ToListAsync();
        }

        public async Task AddCandidateAsync(Candidate candidate)
        {
            await _context.Candidates.AddAsync(candidate);
            await _context.SaveChangesAsync();
        }

        public async Task<Candidate> GetCandidateByIdAsync(Guid id)
        {
            return await _context.Candidates.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task DeleteCandidateAsync(Candidate candidate)
        {
            _context.Candidates.Remove(candidate);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
