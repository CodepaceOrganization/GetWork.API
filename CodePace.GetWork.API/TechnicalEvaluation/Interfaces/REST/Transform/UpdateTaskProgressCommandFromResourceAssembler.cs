using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Commands;
using CodePace.GetWork.API.TechnicalEvaluation.Interfaces.REST.Resources;

namespace CodePace.GetWork.API.TechnicalEvaluation.Interfaces.REST.Transform;

public static class UpdateTaskProgressCommandFromResourceAssembler
{
    public static UpdateTaskProgressCommand ToCommandFromResource(int technicalTaskId, int userId, UpdateTaskProgressResource resource)
    {
        return new UpdateTaskProgressCommand(technicalTaskId, userId, resource.Progress);
    }
}