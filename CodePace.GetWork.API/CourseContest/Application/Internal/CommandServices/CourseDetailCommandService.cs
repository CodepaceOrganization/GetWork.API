using CodePace.GetWork.API.CourseContest.Domain.Model.Entities;
using CodePace.GetWork.API.CourseContest.Domain.Repositories;
using CodePace.GetWork.API.CourseContest.Domain.Services;
using CodePace.GetWork.API.Shared.Domain.Repositories;


namespace CodePace.GetWork.API.CourseContest.Application.Internal.CommandServices;

public class CourseDetailCommandService(ICourseDetailRepository courseDetailRepository, IUnitOfWork unitOfWork) : ICourseDetailCommandService
{
    public async Task CreateCourseDetailAsync(CourseDetail courseDetail)
    {
        await courseDetailRepository.AddAsync(courseDetail);
        await unitOfWork.CompleteAsync();
    }

    public async Task UpdateCourseDetailAsync(CourseDetail courseDetail)
    {
        courseDetailRepository.Update(courseDetail);
        await unitOfWork.CompleteAsync();
    }

    public async Task DeleteCourseDetailAsync(int courseId)
    {
        var courseDetail = await courseDetailRepository.FindByIdAsync(courseId);
        if (courseDetail == null) throw new Exception("Course detail not found");
        courseDetailRepository.Remove(courseDetail);
        await unitOfWork.CompleteAsync();
    }
}