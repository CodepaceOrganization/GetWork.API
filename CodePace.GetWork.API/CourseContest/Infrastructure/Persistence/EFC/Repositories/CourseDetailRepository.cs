using CodePace.GetWork.API.CourseContest.Domain.Model.Aggregates;

namespace CodePace.GetWork.API.CourseContest.Infrastructure.Persistence.EFC.Repositories;

using CodePace.GetWork.API.CourseContest.Domain.Repositories;
using CodePace.GetWork.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CodePace.GetWork.API.Shared.Infrastructure.Persistence.EFC.Repositories;

using Microsoft.EntityFrameworkCore;

public class CourseDetailRepository(AppDbContext context)
    : BaseRepository<CourseDetail>(context), ICourseDetailRepository;