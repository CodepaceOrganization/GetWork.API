using CodePace.GetWork.API.CourseContest.Domain.Model.Entities;

namespace CodePace.GetWork.API.CourseContest.Domain.Services;

public interface ICourseDetailCommandService
{
    Task CreateCourseDetailAsync(CourseDetail courseDetail);
    Task UpdateCourseDetailAsync(CourseDetail courseDetail);
    Task DeleteCourseDetailAsync(int courseId);
}