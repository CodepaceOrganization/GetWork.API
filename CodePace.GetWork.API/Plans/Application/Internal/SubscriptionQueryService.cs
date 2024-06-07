using CodePace.GetWork.API.Plans.Domain.Model.Aggregates;
using CodePace.GetWork.API.Plans.Domain.Model.Queries;
using CodePace.GetWork.API.Plans.Domain.Repositories;
using CodePace.GetWork.API.Plans.Domain.Service;

namespace CodePace.GetWork.API.Plans.Application.Internal;

public class SubscriptionQueryService(ISubscriptionRepository repository) : ISubscriptionQueryService
{
    public async Task<Subscription?> Handle(GetSubscriptionByIdQuery query)
    {
        return await repository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Subscription>> Handle(GetAllSubscriptionsQuery query)
    {
        return await repository.ListAsync();
    }
}