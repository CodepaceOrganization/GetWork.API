using CodePace.GetWork.API.CourseContest.Domain.Model.Commands;
using CodePace.GetWork.API.CourseContest.Domain.Model.Entities;

namespace CodePace.GetWork.API.CourseContest.Domain.Services;

public interface IGoalCommandService
{
    public Task<Goal?> Handle(CreateGoalCommand command);
    public Task<Goal?> Handle(UpdateGoalCommand command);
}