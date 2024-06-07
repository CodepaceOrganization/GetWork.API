using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Entities;
using CodePace.GetWork.API.TechnicalEvaluation.Domain.Repositories;
using CodePace.GetWork.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CodePace.GetWork.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Queries;
using Microsoft.EntityFrameworkCore;

namespace CodePace.GetWork.API.TechnicalEvaluation.Infrastructure.Persistence.EFC.Repositories;

public class TechnicalTaskRepository(AppDbContext context)
    : BaseRepository<TechnicalTask>(context), ITechnicalTaskRepository
{
    public new async Task<IEnumerable<TechnicalTask>> FindTechnicalsTaskByTechnicalTestId(int id)
    {
        Console.WriteLine($"Finding technical tasks with technicalTestId: {id}");
        var tasks = await Context.Set<TechnicalTask>()
            .Where(t=> t.TechnicalTestId == id)
            .ToListAsync();
        Console.WriteLine($"Found {tasks.Count} tasks with technicalTestId: {id}");
        return tasks;
    }
    public new async Task<TechnicalTask?> FindByIdAndUserIdAsync(int id, int userId)
    {
        return await Context.Set<TechnicalTask>()
            .Where(t => t.Id == id && t.TaskProgress.UserId == userId)
            .FirstOrDefaultAsync();
    }
}