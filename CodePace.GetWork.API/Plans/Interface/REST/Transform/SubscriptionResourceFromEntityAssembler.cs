using CodePace.GetWork.API.Plans.Domain.Model.Aggregates;
using CodePace.GetWork.API.Plans.Interface.REST.Resources;

namespace CodePace.GetWork.API.Plans.Interface.REST.Transform;

public class SubscriptionResourceFromEntityAssembler
{
    public static SubscriptionResource ToResourceFromEntity(Subscription entity)
    {
        return new SubscriptionResource(entity.Id, entity.StartDate, entity.EndDate, entity.Cost);
    }
}