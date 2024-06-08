namespace CodePace.GetWork.API.CourseContest.Infrastructure.Persistence.EFC.Repositories;

using CodePace.GetWork.API.CourseContest.Domain.Model.Entities;
using CodePace.GetWork.API.CourseContest.Domain.Repositories;
using CodePace.GetWork.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CodePace.GetWork.API.Shared.Infrastructure.Persistence.EFC.Repositories;

using Microsoft.EntityFrameworkCore;


public class CourseRepository(AppDbContext context) : BaseRepository<Course>(context), ICourseRepository
{
    public new async Task<Course?> FindByIdAsync(int id) =>
            await Context.Set<Course>().FirstOrDefaultAsync(c => c.Id == id);

        public new async Task<IEnumerable<Course>> ListAsync() =>
            await Context.Set<Course>().ToListAsync();
    }