using Microsoft.EntityFrameworkCore;
using Target_Hunting_API.Models;

namespace Target_Hunting_API.Database
{
    public class CandidateDbContext : DbContext
    {
        public CandidateDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Candidate> Candidates { get; set; }
    }
}
