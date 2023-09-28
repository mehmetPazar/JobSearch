using Domain.Entities;
using Persistence.Context;
using Persistence.Repositories.Interfaces;

namespace Persistence.Repositories;

public class ForbiddenWordRepository : GenericRepository<ForbiddenWord>, IForbiddenWordRepository
{
	public ForbiddenWordRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
	}
}