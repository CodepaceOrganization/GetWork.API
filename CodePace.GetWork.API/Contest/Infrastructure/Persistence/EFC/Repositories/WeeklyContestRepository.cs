using CodePace.GetWork.API.contest.Domain.Model.Aggregates;
using CodePace.GetWork.API.contest.Domain.Model.Entities;
using CodePace.GetWork.API.contest.Domain.Repositories;
using CodePace.GetWork.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CodePace.GetWork.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CodePace.GetWork.API.contest.Infrastructure.Persistence.EFC.Repositories;

public class WeeklyContestRepository(AppDbContext context) : BaseRepository<WeeklyContest>(context), IWeeklyContestRepository;