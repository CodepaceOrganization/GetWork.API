using CodePace.GetWork.API.CourseContest.Domain.Model.Aggregates;
using CodePace.GetWork.API.CourseContest.Domain.Model.Entities;
using CodePace.GetWork.API.CourseContest.Domain.Repositories;
using CodePace.GetWork.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CodePace.GetWork.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace CodePace.GetWork.API.CourseContest.Infrastructure.Persistence.EFC.Repositories;

public class GoalRepository(AppDbContext context)
    : BaseRepository<Goal>(context), IGoalRepository;
