using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Entities;
using CodePace.GetWork.API.TechnicalEvaluation.Domain.Repositories;
using CodePace.GetWork.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CodePace.GetWork.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Queries;
using Microsoft.EntityFrameworkCore;

namespace CodePace.GetWork.API.TechnicalEvaluation.Infrastructure.Persistence.EFC.Repositories;

public class TaskProgressRepository(AppDbContext context)
    : BaseRepository<TaskProgress>(context), ITaskProgressRepository
{
    public new async Task<IEnumerable<TaskProgress>> FindTaskProgressByTechnicalTaskId(int technicalTaskId)
    {
        return await Context.Set<TaskProgress>()
            .Where(t => t.TechnicalTaskId == technicalTaskId)
            .ToListAsync();
    }
}