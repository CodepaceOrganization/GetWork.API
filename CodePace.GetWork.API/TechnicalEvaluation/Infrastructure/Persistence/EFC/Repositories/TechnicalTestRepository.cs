using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Aggregates;
using CodePace.GetWork.API.TechnicalEvaluation.Domain.Repositories;
using CodePace.GetWork.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CodePace.GetWork.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CodePace.GetWork.API.TechnicalEvaluation.Infrastructure.Persistence.EFC.Repositories;

public class TechnicalTestRepository(AppDbContext context) : BaseRepository<TechnicalTest>(context), ITechnicalTestRepository
{
    public new async Task<TechnicalTest?> FindByIdAsync(int id) =>
        await Context.Set<TechnicalTest>().Include(t => t.TechnicalTasks). 
            Where(t => t.Id == id).FirstOrDefaultAsync();
    
    public new async Task<IEnumerable<TechnicalTest>> ListAsync()
    {
        return await Context.Set<TechnicalTest>()
            .Include(TechnicalTest => TechnicalTest.TechnicalTasks)
            .ToListAsync();
    }
    public async Task<IEnumerable<TechnicalTest>> FindByTechnicalTaskIdAsync(int technicalTaskId)
    {
        return await Context.Set<TechnicalTest>()
            .Include(TechnicalTest => TechnicalTest.TechnicalTasks)
            .Where(TechnicalTest => TechnicalTest.TechnicalTaskId == technicalTaskId)
            .ToListAsync();
    }
}