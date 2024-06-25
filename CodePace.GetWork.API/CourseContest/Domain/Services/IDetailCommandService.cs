using CodePace.GetWork.API.CourseContest.Domain.Model.Aggregates;
using CodePace.GetWork.API.CourseContest.Domain.Model.Commands;
using CodePace.GetWork.API.CourseContest.Domain.Model.Entities;

namespace CodePace.GetWork.API.CourseContest.Domain.Services;

public interface IDetailCommandService
{
    public Task<CourseDetail?> Handle(CreateCourseDetailCommand command);
    public Task<CourseDetail?> Handle(UpdateCourseDetailCommand command);
}