using CodePace.GetWork.API.Plans.Domain.Model.Aggregates;
using CodePace.GetWork.API.Plans.Domain.Model.Commands;

namespace CodePace.GetWork.API.Plans.Domain.Service;

public interface ISubscriptionCommandService
{
    Task<Subscription?> Handle(CreateSubscriptionCommand command);
}