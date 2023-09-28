using Domain.Entities;
using Persistence.Context;
using Persistence.Repositories.Interfaces;

namespace Persistence.Repositories;

public class EmployerRepository : GenericRepository<Employer>, IEmployerRepository
{
    public EmployerRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}