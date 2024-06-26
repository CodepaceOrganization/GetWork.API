using CodePace.GetWork.API.IAM.Domain.Model.Commands;
using CodePace.GetWork.API.IAM.Interfaces.REST.Resources;

namespace CodePace.GetWork.API.IAM.Interfaces.REST.Transform;

public static class SignUpCommandFromResourceAssembler
{
    public static SignUpCommand ToCommandFromResource(SignUpResource resource)
    {
        return new SignUpCommand(resource.Username, resource.Password);
    }
}