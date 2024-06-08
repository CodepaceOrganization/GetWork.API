namespace CodePace.GetWork.API.CourseContest.Infrastructure.Persistence.EFC.Repositories;

using CodePace.GetWork.API.CourseContest.Domain.Model.Entities;
using CodePace.GetWork.API.CourseContest.Domain.Repositories;
using CodePace.GetWork.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CodePace.GetWork.API.Shared.Infrastructure.Persistence.EFC.Repositories;

using Microsoft.EntityFrameworkCore;

public class CourseDetailRepository(AppDbContext context)
    : BaseRepository<CourseDetail>(context), ICourseDetailRepository
{
    public new async Task<CourseDetail?> FindByIdAsync(int id) =>
        await Context.Set<CourseDetail>().Include(cd => cd.Course)
            .Where(cd => cd.Id == id).FirstOrDefaultAsync();

    public new async Task<IEnumerable<CourseDetail>> ListAsync() =>
        await Context.Set<CourseDetail>().Include(cd => cd.Course).ToListAsync();

    public async Task<CourseDetail?> GetByCourseIdAsync(int courseId) =>
        await Context.Set<CourseDetail>().Include(cd => cd.Course)
            .Where(cd => cd.CourseId == courseId).FirstOrDefaultAsync();
}