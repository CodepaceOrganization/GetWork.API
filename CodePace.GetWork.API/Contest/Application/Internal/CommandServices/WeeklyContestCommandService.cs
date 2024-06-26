using CodePace.GetWork.API.contest.Domain.Model.Aggregates;
using CodePace.GetWork.API.contest.Domain.Model.Commands;
using CodePace.GetWork.API.contest.Domain.Model.Entities;
using CodePace.GetWork.API.contest.Domain.Repositories;
using CodePace.GetWork.API.contest.Domain.Services;
using CodePace.GetWork.API.Shared.Domain.Repositories;

namespace CodePace.GetWork.API.contest.Application.Internal.CommandServices;

public class WeeklyContestCommandService(IWeeklyContestRepository weeklyContestRepository, IUnitOfWork unitOfWork)
    :IWeeklyContestCommandService
{
    public async Task<WeeklyContest?> Handle(CreateWeeklyContestCommand command)
    {
        var weeklyContests = await weeklyContestRepository.ListAsync();
        if (weeklyContests.Count() >= 4)
        {
            throw new InvalidOperationException("Cannot create more than 4 weekly contests.");
        }

        var weeklycontest = new WeeklyContest(command.Title, command.Urlimage, command.Date);
        await weeklyContestRepository.AddAsync(weeklycontest);
        await unitOfWork.CompleteAsync();
        return weeklycontest;
    }

    public async Task<WeeklyContest?> Handle(UpdateWeeklyContestCommand command)
    {
        var contest = await weeklyContestRepository.FindByIdAsync(command.Id);
        if(contest == null)
        {
            return null;
        }
        contest.UpdateTitle(command.Title);
        contest.UpdateUrlImage(command.UrlImage);
        contest.UpdateDate(command.Date);
        await unitOfWork.CompleteAsync();
        return contest;
    }
}