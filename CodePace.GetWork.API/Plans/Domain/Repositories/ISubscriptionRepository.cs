using CodePace.GetWork.API.Plans.Domain.Model.Aggregates;
using CodePace.GetWork.API.Shared.Domain.Repositories;

namespace CodePace.GetWork.API.Plans.Domain.Repositories;

public interface ISubscriptionRepository : IBaseRepository<Subscription>
{
    Task<Subscription?> FindByIdAsync(long id);
    Task<IEnumerable<Subscription>> ListAsync();
}