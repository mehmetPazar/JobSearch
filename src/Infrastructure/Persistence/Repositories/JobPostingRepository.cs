using Domain.Entities;
using Persistence.Context;
using Persistence.Repositories.Interfaces;

namespace Persistence.Repositories;

public class JobPostingRepository : GenericRepository<JobPosting>, IJobPostingRepository
{
	public JobPostingRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
	}
}