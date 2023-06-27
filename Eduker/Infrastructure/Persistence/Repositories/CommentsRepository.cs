using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class CommentsRepository: ICommentsRepository
{
    private readonly EduckerDbContext _dbContext;

    public CommentsRepository(EduckerDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IEnumerable<Comments>> GetAllAsync()
    {
        var comments = await _dbContext.Comments
            .Include(c =>c.Course)
            .ToListAsync();
        return comments;
    }
    
    
}