using System.Collections.Generic;
using System.Threading.Tasks;
using CodePace.GetWork.API.contest.Domain.Model.Aggregates;
using CodePace.GetWork.API.contest.Domain.Model.Entities;
using CodePace.GetWork.API.contest.Domain.Repositories;
using CodePace.GetWork.API.Shared.Domain.Repositories;
using CodePace.GetWork.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CodePace.GetWork.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
namespace CodePace.GetWork.API.contest.Infrastructure.Persistence.EFC.Repositories;

public class ContestRepository : BaseRepository<Contest>, IContestRepository
{
    private readonly AppDbContext _context;

    public ContestRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public Contest GetContestById(int id)
    {
        return _context.Contests.FirstOrDefault(c => c.Id == id);
    }
}