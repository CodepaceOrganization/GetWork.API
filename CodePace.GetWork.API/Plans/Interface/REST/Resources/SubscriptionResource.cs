using CodePace.GetWork.API.Plans.Domain.Model.ValueObjects;

namespace CodePace.GetWork.API.Plans.Interface.REST.Resources;

public record SubscriptionResource(long Id, DateTime StartDate, DateTime EndDate, float Cost);