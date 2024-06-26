using CodePace.GetWork.API.contest.Domain.Model.Commands;
using CodePace.GetWork.API.contest.Interfaces.REST.Resources;

namespace CodePace.GetWork.API.contest.Interfaces.REST.Transform;

public class CreateWeeklyContestCommandFromResourceAssembler
{
    public static CreateWeeklyContestCommand ToCommandFromResource(CreateWeeklyContestResource resource)
    {
        return new CreateWeeklyContestCommand(resource.ContestId,resource.Title, resource.UrlImage, resource.Date);
    }
}