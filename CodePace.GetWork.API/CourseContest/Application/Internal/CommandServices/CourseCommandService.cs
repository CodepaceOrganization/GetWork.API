using CodePace.GetWork.API.CourseContest.Domain.Model.Commands;
using CodePace.GetWork.API.CourseContest.Domain.Model.Entities;
using CodePace.GetWork.API.CourseContest.Domain.Repositories;
using CodePace.GetWork.API.CourseContest.Domain.Services;
using CodePace.GetWork.API.Shared.Domain.Repositories;

namespace CodePace.GetWork.API.CourseContest.Application.Internal.CommandServices;

public class CourseCommandService(ICourseRepository courseRepository, IUnitOfWork unitOfWork) : ICourseCommandService
{
    public async Task CreateCourseAsync(Course course)
    {
        await courseRepository.AddAsync(course);
        await unitOfWork.CompleteAsync();
    }
    
    public async Task UpdateCourseAsync(Course course)
    {
        courseRepository.Update(course);
        await unitOfWork.CompleteAsync();
    }

    public async Task DeleteCourseAsync(int id)
    {
        var course = await courseRepository.FindByIdAsync(id);
        if (course == null) throw new Exception("Course not found");
        courseRepository.Remove(course);
        await unitOfWork.CompleteAsync();
    }

    public Task<Course> Handle(CreateCourseCommand createCourseCommand)
    {
        throw new NotImplementedException();
    }
}