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
    public new async Task<IEnumerable<TechnicalTask>> FindTechnicalsTestByTechnicalTestId(int id)
    {
        return await Context.Set<TechnicalTask>()
            .Where(t=> t.TechnicalTestId == id)
            .ToListAsync();
    }
}