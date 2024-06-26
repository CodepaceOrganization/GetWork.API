using CodePace.GetWork.API.IAM.Domain.Model.Commands;
using CodePace.GetWork.API.IAM.Interfaces.REST.Resources;

namespace CodePace.GetWork.API.IAM.Interfaces.REST.Transform;

public static class SignInCommandFromResourceAssembler
{
    public static SignInCommand ToCommandFromResource(SignInResource resource)
    {
        return new SignInCommand(resource.Username, resource.Password);
    }
}