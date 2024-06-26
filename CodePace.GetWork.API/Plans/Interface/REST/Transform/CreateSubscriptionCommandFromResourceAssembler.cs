using CodePace.GetWork.API.Plans.Domain.Model.Commands;
using CodePace.GetWork.API.Plans.Interface.REST.Resources;

namespace CodePace.GetWork.API.Plans.Interface.REST.Transform;

public class CreateSubscriptionCommandFromResourceAssembler
{
    public static CreateSubscriptionCommand ToCommandFromResource(CreateSubscriptionResource resource)
    {
        return new CreateSubscriptionCommand(resource.Cost);
    }
}