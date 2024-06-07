using CodePace.GetWork.API.Plans.Domain.Model.Aggregates;
using CodePace.GetWork.API.Plans.Domain.Model.Commands;
using CodePace.GetWork.API.Plans.Domain.Repositories;
using CodePace.GetWork.API.Plans.Domain.Service;
using CodePace.GetWork.API.Shared.Domain.Repositories;

namespace CodePace.GetWork.API.Plans.Application.Internal;

public class SubscriptionCommandService(ISubscriptionRepository repository, IUnitOfWork unitOfWork) : ISubscriptionCommandService
{
    public async Task<Subscription?> Handle(CreateSubscriptionCommand command)
    {
        var subscription = new Subscription(command);
        await repository.AddAsync(subscription);
        await unitOfWork.CompleteAsync();
        return subscription;
    }
}