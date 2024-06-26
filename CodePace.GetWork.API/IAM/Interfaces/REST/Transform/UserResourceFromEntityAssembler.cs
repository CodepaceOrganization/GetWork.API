using CodePace.GetWork.API.IAM.Domain.Model.Aggregates;
using CodePace.GetWork.API.IAM.Interfaces.REST.Resources;

namespace CodePace.GetWork.API.IAM.Interfaces.REST.Transform;

public static class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User user)
    {
        return new UserResource(user.Id, user.Username);
    }
}