using CodePace.GetWork.API.CourseContest.Domain.Model.Commands;
using CodePace.GetWork.API.CourseContest.Domain.Model.Entities;
using CodePace.GetWork.API.CourseContest.Domain.Repositories;
using CodePace.GetWork.API.CourseContest.Domain.Services;
using CodePace.GetWork.API.Shared.Domain.Repositories;

namespace CodePace.GetWork.API.CourseContest.Application.Internal.CommandServices;

public class GoalCommandService(IGoalRepository goalRepository, IUnitOfWork unitOfWork)
    : IGoalCommandService
{
    public async Task<Goal?> Handle(CreateGoalCommand command)
    {
        var goal = new Goal(
            command.CourseDetailId,
            command.Value
        );
        await goalRepository.AddAsync(goal);
        await unitOfWork.CompleteAsync();
        return goal;
    }
    
    public async Task<Goal?> Handle(UpdateGoalCommand command)
    {
        var goal = await goalRepository.FindByIdAsync(command.Id);
        if (goal == null)
        {
            throw new ArgumentException("No goal with the provided ID could be found.", nameof(UpdateGoalCommand.Id));
        }

        goal.UpdateValue(command.Value);

        await unitOfWork.CompleteAsync();
        return goal;
    }
}