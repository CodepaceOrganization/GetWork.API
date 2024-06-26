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
        return await Context.Set<TechnicalTask>()
            .Where(t=> t.TechnicalTestId == id)
            .ToListAsync();
    }
    public new async Task<TechnicalTask?> FindByIdAndUserIdAsync(int id, int userId)
    {
        return await Context.Set<TechnicalTask>()
            .Where(t => t.Id == id && t.TaskProgress.UserId == userId)
            .FirstOrDefaultAsync();
    }
    public async Task<TaskProgress?> FindTaskProgress(int technicalTaskId, int userId)
    {
        return await Context.Set<TaskProgress>()
            .Where(tp => tp.TechnicalTask.Id == technicalTaskId && tp.UserId == userId)
            .FirstOrDefaultAsync();
    }
    public async Task AddTaskProgress(TaskProgress taskProgress)
    {
        await Context.Set<TaskProgress>().AddAsync(taskProgress);
        await Context.SaveChangesAsync();
    }

    public async Task UpdateTaskProgress(int id, TaskProgress taskProgress)
    {
        var existingTaskProgress = await Context.Set<TaskProgress>().FirstOrDefaultAsync(t => t.TechnicalTaskId == id);
    
        if (existingTaskProgress == null)
        {
            throw new Exception($"No TaskProgress record found with the technical_task_id of {id}");
        }

        existingTaskProgress.Progress = taskProgress.Progress;
        await Context.SaveChangesAsync();
    }
    public async Task<IEnumerable<TechnicalTask>> GetAllTechnicalTaskByUserId(int userId, int technicalTestId)
    {
        return await Context.Set<TechnicalTask>()
            .Include(t => t.TaskProgress)
            .Where(t => t.TaskProgress.UserId == userId && t.TechnicalTestId == technicalTestId)
            .ToListAsync();
    }
}