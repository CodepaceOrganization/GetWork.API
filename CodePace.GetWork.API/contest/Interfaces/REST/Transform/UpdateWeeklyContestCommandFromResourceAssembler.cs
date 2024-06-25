using CodePace.GetWork.API.contest.Domain.Model.Commands;
using CodePace.GetWork.API.contest.Interfaces.REST.Resources;

namespace CodePace.GetWork.API.contest.Interfaces.REST.Transform;

public class UpdateWeeklyContestCommandFromResourceAssembler
{
    public static UpdateWeeklyContestCommand ToCommandFromResource(UpdateWeeklyContestResource resource)
    {
        return new UpdateWeeklyContestCommand(resource.Id,resource.Title, resource.UrlImage, resource.Date);
    }
}